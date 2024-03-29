﻿using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
using Main.Data.Context;
using Main.Data.Repositories;
using Main.Domain.Interfaces;
using Main.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Main.IoC
{
    public static class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IAboutUsServices, AboutUsServices>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IProductImageGalleryRepository,ProductImageGalleryRepository >();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductImageGalleryService, ProductImageGalleryService>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();
            services.AddScoped<IPropertiesService, PropertiesService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentService, PaymentService>();
          


        }
    }
}
