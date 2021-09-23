using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using System;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.Services;
using AutoMapper;

namespace PL
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingSettings());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IWorkingHistoryRepository, WorkingHistoryRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IManagerService, ManagerService>();

            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            string connectionString = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<ShopsDBContext>(options => options.UseSqlServer(connectionString));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = @"D:\Projects\NesterenkoEugene\ShopsWithManagers\PL\ClientApp\";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = @"D:\Projects\NesterenkoEugene\ShopsWithManagers\PL\ClientApp\";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
