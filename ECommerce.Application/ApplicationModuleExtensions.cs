using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.IServices;
using ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Application
{
    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService,UserService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddInfrastructureModule(configuration);

            return services;
        }
    }
}
