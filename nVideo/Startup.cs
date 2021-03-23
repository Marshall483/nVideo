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
using nVideo.DATA.Interfaces;
using nVideo.DATA.Repository;
using nVideo.DATA.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace nVideo
{
    public class Startup
    {
        private readonly IConfigurationRoot _connectionString;

        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _connectionString = new ConfigurationBuilder().
                                    SetBasePath(hostEnvironment.ContentRootPath). // Получить путь к корневой папке
                                    AddJsonFile("DbSettings.json"). // Имя самого файла
                                    Build();
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(_connectionString.GetConnectionString("DefaultConnection"))); // Подключить контекст бд

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            })
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
                

            /* Lifetime */
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();


            /* IMPOTANT */
            services.AddMvc(option => option.EnableEndpointRouting = false); // Добавть MVC
            services.AddMemoryCache(); // Подлючить библиотеку с кешами
            services.AddSession(); // Подлючить дополнительную библиотеку с сессиями
            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme) //Redirect to login
                .AddCookie(options => // CookieConfigurationOptions
                {
                    options.LoginPath = new PathString("/Account/Register");
                });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
