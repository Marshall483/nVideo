using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using nVideo.DATA;
using nVideo.Models;

namespace nVideo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope()){
                try{
                    var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DbObjects.Initial(context);

                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var rolesManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    RoleInitializer.InitializeAsync(userManager, rolesManager).Wait();
                }
                catch(Exception ex){
                    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError($"An error occured while initializing Db -\n{ex.Message} ");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();
                logging.AddConsole(options => options.IncludeScopes = true);
                logging.AddDebug();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
