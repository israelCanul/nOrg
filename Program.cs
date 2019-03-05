﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace narilearsi
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) {
            IWebHostBuilder builder = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory());


            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                IHostingEnvironment env = hostingContext.HostingEnvironment;
                config.AddJsonFile(
                        "appsettings.json",
                        optional: true,
                        reloadOnChange: true
                    ).AddJsonFile(
                        $"appsettings.{env.EnvironmentName}.json",
                        optional: true,
                        reloadOnChange: true
                    );
                config.AddEnvironmentVariables();
                if (args != null)
                {
                    config.AddCommandLine(args);
                }                
            });
            
            return builder.UseStartup<Startup>()
                           .UseUrls("http://localhost:5020").Build();
        }
            
    }
}
