﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infrastructure
{
    public static class InfrastructureModuleExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ECommerceDbContext>(
            //    options => options.UseNpgsql(configuration.GetConnectionString("Default"),
            //        b=>b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
            //    );

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
