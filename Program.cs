using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace narilearsi
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddCommandLine(args);
                    config.Build();
                })
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000");
        }


            //IWebHostBuilder builder = new WebHostBuilder()
            //.UseKestrel()
            //.UseContentRoot(Directory.GetCurrentDirectory());


            //builder.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    IHostingEnvironment env = hostingContext.HostingEnvironment;
            //    config.AddJsonFile(
            //            "appsettings.json",
            //            optional: true,
            //            reloadOnChange: true
            //        ).AddJsonFile(
            //            $"appsettings.{env.EnvironmentName}.json",
            //            optional: true,
            //            reloadOnChange: true
            //        );
            //    config.AddEnvironmentVariables();
            //    if (args != null)
            //    {
            //        config.AddCommandLine(args);
            //    }
            //})
            //.ConfigureLogging((hostingContext, logging) =>
            //{
            //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            //    logging.AddConsole();
            //    logging.AddDebug();
            //})
            //.UseIISIntegration()
            //.UseDefaultServiceProvider(
            //        (context, options) => { options.ValidateScopes = context.HostingEnvironment.IsDevelopment(); });


            //return builder.UseStartup<Startup>()
            //               .UseUrls("http://localhost:5020").Build();
        
            
    }
}
