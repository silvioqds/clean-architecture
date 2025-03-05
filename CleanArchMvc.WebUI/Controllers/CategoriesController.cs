using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;               
        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;            
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategoriesAsync(cancellationToken);            
            return View(categories);
        }
    }
}
