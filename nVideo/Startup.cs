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

namespace nVideo
{
    public class Startup
    {
        private protected readonly string _dbConnection;

        public Startup(IConfiguration configuration){
            Configuration = configuration;
            // �� ����� �������, ���� �� ������ ���� � ��������� ���������� ������ ����������� � 
            // ������ ConnectionStrings:dbConnectionString
            _dbConnection = Configuration["ConnectionStrings:dbConnectionString"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services){
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(_dbConnection)); // ���������� �������� ��

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // ����������� �����
                opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                opts.Password.RequireDigit = false; // ��������� �� �����
            })
              .AddEntityFrameworkStores<AppDBContext>()
              .AddDefaultTokenProviders();
                

            /* Lifetime */
            services.AddTransient<IAllCatalog, CatalogRepository>();
            services.AddSingleton<EmailSenderService>();


            /* IMPOTANT */
            services.AddMvc(option => option.EnableEndpointRouting = false); // ������� MVC
            services.AddMemoryCache(); // ��������� ���������� � ������
            services.AddSession(); // ��������� �������������� ���������� � ��������
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();  // ����������� ������ 400,404,500...
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
                    pattern: "{controller=Account}/{action=Register}/{id?}");
            });
        }
    }
}
