
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsRU.Application.DiscountStrategies;
using ShopsRU.Application.Interfaces.Repositories;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Application.Interfaces.UnitOfWork;
using ShopsRU.Persistence.Context.EntityFramework;
using ShopsRU.Persistence.Implementations.Repositories;
using ShopsRU.Persistence.Implementations.Services;
using ShopsRU.Persistence.Implementations.UnitOfWork;

namespace ShopsRU.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddDbContext<ShopsRUContext>(x => x.UseSqlServer(configuration.GetConnectionString("ShopsRUConString")));
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            #endregion
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
