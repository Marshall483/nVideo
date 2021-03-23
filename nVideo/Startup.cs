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
                                    SetBasePath(hostEnvironment.ContentRootPath). // �������� ���� � �������� �����
                                    AddJsonFile("DbSettings.json"). // ��� ������ �����
                                    Build();
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(_connectionString.GetConnectionString("DefaultConnection"))); // ���������� �������� ��

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // ����������� �����
                opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                opts.Password.RequireDigit = false; // ��������� �� �����
            })
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
                

            /* Lifetime */
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();


            /* IMPOTANT */
            services.AddMvc(option => option.EnableEndpointRouting = false); // ������� MVC
            services.AddMemoryCache(); // ��������� ���������� � ������
            services.AddSession(); // ��������� �������������� ���������� � ��������
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
