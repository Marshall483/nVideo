using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using nVideo.DATA;
using nVideo.Models;

namespace nVideo
{
    public class Startup
    {
        private protected readonly string _dbConnection;

        public Startup(IConfiguration configuration){
            Configuration = configuration;
            _dbConnection = Configuration["ConnectionStrings:dbConnectionString"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(_dbConnection)); // Подключить контекст бд

            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<AppDBContext>().
                AddDefaultTokenProviders();



            /* IMPOTANT */
            services.AddMvc(option => option.EnableEndpointRouting = false); // Добавть MVC
            services.AddMemoryCache(); // Подлючить дополнительную библиотеку с кешами
            services.AddSession(); // Подлючить дополнительную библиотеку с сессиями
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();  // Отображение ошибок 400,404,500...
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
