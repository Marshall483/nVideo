using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace BLL
{
    public static class Extention
    {
        public static IServiceCollection ConfigureBussinessLogic(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddHttpContextAccessor();
            
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();
            services.AddSingleton<NotificatorService>();
            services.AddTransient<INotificator, EmailNotificationService>();
            services.AddTransient<OrderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(x => ShopCart.GetCart(x));

            return services;
        }
    }
}
