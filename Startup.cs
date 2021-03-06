﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelNari;
using narilearsi.Data;
using narilearsi.ModelDB;
using narilearsi.Services;

namespace narilearsi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddMvcCore()
                    //.AddAuthorization()
                    .AddJsonFormatters();
            services.AddDbContext<DBContext>(options => {
                //options.UseSqlServer("Server= rdsdev.cyizhh2mbeac.us-east-1.rds.amazonaws.com\\SQLEXPRESS,4389;Database=narilearsi;User ID=israelcanul;Password=12345678");
                options.UseSqlServer("Server=DESKTOP-KA36I15\\SQLEXPRESS;Database=narilearsi;Trusted_Connection=True;");
            });
            services.AddAuthentication("Bearer")
                 .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.RequireHttpsMetadata = false;
                        options.Audience = "narilearsi";
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Persons, PersonWithEventOnly>();
                config.CreateMap<Event, EventWithoutEventType>();
            });
            app.UseMvc();
        }
    }
}
