using Microsoft.Extensions.DependencyInjection;
using Service.MappingProfiels;
using ServiceAbstraction;

namespace Service
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Service Manager
            services.AddScoped<IServiceManager, ServiceManagerWithFactoryDelegate>();

            // Product Service
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<Func<IProductService>>(provider =>
                () => provider.GetRequiredService<IProductService>()
            );

            // Basket Service
            services.AddScoped<IBasketServices, BasketServices>();
            services.AddScoped<Func<IBasketServices>>(provider =>
                () => provider.GetRequiredService<IBasketServices>()
            );

            // Order Service
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<Func<IOrderService>>(provider =>
                () => provider.GetRequiredService<IOrderService>()
            );

            // Authentication Service
            services.AddScoped<IAuthentacationService, AuthentcationService>();
            services.AddScoped<Func<IAuthentacationService>>(provider =>
                () => provider.GetRequiredService<IAuthentacationService>()
            );

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<Func<IPaymentService>>(provider =>
                () => provider.GetRequiredService<IPaymentService>()
            );


            // AutoMapper Profiles
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName != null && a.FullName.StartsWith("Service"))
                .ToArray());


            services.AddScoped<ICasheService, CasheService>();

            return services;
        }
    }
}
