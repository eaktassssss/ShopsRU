﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsRU.Application.Contract.Request.Product;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Application.Validators;
using ShopsRU.Domain.Entities;
using ShopsRU.Infrastructure.Resources;
using ShopsRU.Persistence.Context.EntityFramework;
using ShopsRU.Persistence.Implementations.Repositories;
using ShopsRU.Persistence.Implementations.Services;
using ShopsRU.Persistence.Implementations.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddDbContext<ShopsRUContext>(x => x.UseSqlServer(configuration.GetConnectionString("ShopsRUConString")));
            services.AddScoped<ICustomerTypeService, CustomerTypeService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ICustomerDiscountService, CustomerDiscountService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IDiscountStrategy, DiscountStrategy>();
         
            #endregion
            #region Repositories DI
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            #endregion
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
