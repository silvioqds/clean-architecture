using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Commands;
using CleanArchMvc.Application.UseCases.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IMediator mediator, IMapper mapper, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _mapper = mapper;
            _categoryService = categoryService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = await _mediator.Send(new GetProductsQuery(), CancellationToken.None);
            return View(products);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(CancellationToken.None), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(CancellationToken.None), "Id", "Name");
            if (ModelState.IsValid)
            {
                ProductCreateCommand createCommand = _mapper.Map<ProductCreateCommand>(productDto);
                await _mediator.Send(createCommand, CancellationToken.None);
                return RedirectToAction(nameof(Index));
            }

            return View(productDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            ProductDTO productDto = await _mediator.Send(new GetProductByIdQuery(id.GetValueOrDefault()), CancellationToken.None);

            if (productDto == null) return NotFound();

            var categories = await _categoryService.GetCategoriesAsync(CancellationToken.None);
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDto.CategoryId);

            return View(productDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {

            ProductUpdateCommand updateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(updateCommand, CancellationToken.None);
            return RedirectToAction(nameof(Index));            
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            ProductDTO productDto = await _mediator.Send(new GetProductByIdQuery(id.GetValueOrDefault()), CancellationToken.None);

            if (productDto == null)
                return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ProductRemoveCommand removeCommand = new ProductRemoveCommand(id);
            await _mediator.Send(removeCommand, CancellationToken.None);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            ProductDTO productDto = await _mediator.Send(new GetProductByIdQuery(id.GetValueOrDefault()), CancellationToken.None);

            if (productDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }
    }
}
