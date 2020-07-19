using Microsoft.Extensions.DependencyInjection;
using Narvan.DataAccessCommands.Commons;
using Narvan.DataAccessCommands.Products.Repositories;
using Narvan.DataAccessCommands.Roles.Repositories;
using Narvan.DataAccessCommands.Sliders.Repositories;
using Narvan.DataAccessCommands.Users.Repositories;
using Narvan.DataAccessQueries.Products.Repositories;
using Narvan.DataAccessQueries.Roles.Repositories;
using Narvan.DataAccessQueries.Sliders.Repositories;
using Narvan.DataAccessQueries.Users.Repositories;
using Narvan.Domains.Commons;
using Narvan.Domains.Commons.Securities;
using Narvan.Domains.Products.Repositories;
using Narvan.Domains.Roles.Repositories;
using Narvan.Domains.Sliders.Repositories;
using Narvan.Domains.Users.Repositories;
using Narvan.WebApi.Utilities.Convertors;

namespace Narvan.WebApi.Utilities.Extentions.Iocs
{
    public static class IocExtention
    {
        public static IServiceCollection AddIoc(this IServiceCollection services)
        {


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepositoryCommand, UserRepositoryCommand>();
            services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();

            services.AddScoped<IRoleRepositoryCommand, RoleRepositoryCommand>();
            services.AddScoped<IRoleRepositoryQuery, RoleRepositoryQuery>();

            services.AddScoped<ISliderRepositoryCommand, SliderRepositoryCommand>();
            services.AddScoped<ISliderRepositoryQuery, SliderRepositoryQuery>();

            services.AddScoped<IPasswordHelper, PasswordHelper>();

            services.AddScoped<IViewRenderService, RenderViewToString>();

            services.AddScoped<IProductRepositoryCommand, ProductRepositoryCommand>();
            services.AddScoped<IProductRepositoryQuery, ProductRepositoryQuery>();


            return services;
        }
    }
}