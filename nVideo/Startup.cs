using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using nVideo.DATA.Interfaces;
using nVideo.DATA.Repository;
using nVideo.DATA.Services;
using Location;

namespace nVideo
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();
            services.AddSingleton<NotificatorService>();
            services.AddTransient<INotificator, EmailNotificationService>();
            services.AddTransient<OrderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(x => ShopCart.GetCart(x));

            
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/Error/status", "?code={0}"); app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<CitiesMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}