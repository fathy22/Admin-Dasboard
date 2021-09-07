using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyDemo.BL.Intrfaces;
using MyDemo.BL.Mapper;
using MyDemo.BL.Repository;
using MyDemo.DAL.Entities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; } // TO MATCH COONECTIONSTRING   
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

     

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix) //LOCALIZATION
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(opt=> {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();  //adding NewtonsoftJson Package to map between jquery and .Net ==> (Serilization)
                });
            // to add conectionstring
            services.AddDbContextPool<DeptDbContext> 
                (option => option.UseSqlServer(Configuration.GetConnectionString("MyDemoDBConnection")));

            // to link between IRepository and Repository
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // to add auto mapper
            services.AddAutoMapper(mapper => mapper.AddProfile(new DomainProfile()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Take Instance From Languages
            var supportedCultures = new[] {
                  new CultureInfo("ar-EG"),
                  new CultureInfo("en-US"),
            };
// to override about site how to start :english or arabic
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
