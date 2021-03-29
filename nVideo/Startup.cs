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

<<<<<<< HEAD
        public Startup(IConfiguration configuration){
            Configuration = configuration;
            // пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ 
            // пїЅпїЅпїЅпїЅпїЅпїЅ ConnectionStrings:dbConnectionString
            _dbConnection = Configuration["ConnectionStrings:dbConnectionString"];
=======
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _connectionString = new ConfigurationBuilder().
                                    SetBasePath(hostEnvironment.ContentRootPath). // Получить путь к корневой папке
                                    AddJsonFile("DbSettings.json"). // Имя самого файла
                                    Build();
>>>>>>> iss30
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(options =>
<<<<<<< HEAD
                options.UseNpgsql(_dbConnection)); // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ
=======
                options.UseNpgsql(_connectionString.GetConnectionString("DefaultConnection"))); // Подключить контекст бд
>>>>>>> iss30

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
                opts.Password.RequireNonAlphanumeric = false;   // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ-пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ
                opts.Password.RequireLowercase = false; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
                opts.Password.RequireUppercase = false; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
                opts.Password.RequireDigit = false; // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
            })
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
                

            /* Lifetime */
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();


            /* IMPOTANT */
            services.AddMvc(option => option.EnableEndpointRouting = false); // пїЅпїЅпїЅпїЅпїЅпїЅпїЅ MVC
            services.AddMemoryCache(); // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
            services.AddSession(); // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme) //Redirect to login
                .AddCookie(options => // CookieConfigurationOptions
                {
                    options.LoginPath = new PathString("~/Account/Register");
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){

            app.UseDeveloperExceptionPage();
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
                    pattern: "{controller=Account}/{action=Register}/{id?}");
            });
        }
    }
}
