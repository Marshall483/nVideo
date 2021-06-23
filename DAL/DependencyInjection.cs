using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using DAL;

namespace DataAccess
{
    public static class Extenstion
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Database>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))); 

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
              .AddEntityFrameworkStores<Database>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("~/Account/Register");
                });
                
            return services;
        }
    }
}