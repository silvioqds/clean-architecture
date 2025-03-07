using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>() // Inclui a configuração do identity padrão para usuários e roles
                .AddEntityFrameworkStores<ApplicationDbContext>()// Inclui a implementação do EF Core do Identity para realizar a persistencia no SQL Server
                .AddDefaultTokenProviders(); // Adiciona provedores de token para gerar tokens de redefinição de senha, alteração de email e etc

            //Sempre que o usuário acessar uma rota que ele não possui acesso, irá redirecionar para "account/login"
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //AutoMappers
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            return services;
        }
    }
}
