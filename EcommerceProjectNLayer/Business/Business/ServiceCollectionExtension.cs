using System;
using Business.Cart;
using Business.Mapper;
using Business.Product;
using Business.User;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessModules(this IServiceCollection services
          
            )
        {
            services.AddAutoMapper(typeof(ProductMapper));
            services.AddDalModules();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService,ProductService>();
            return services;
        }
    }
   
}

