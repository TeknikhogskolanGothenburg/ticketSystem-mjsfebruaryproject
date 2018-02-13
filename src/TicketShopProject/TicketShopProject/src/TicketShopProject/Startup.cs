using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TicketShopProject.Data;
using Microsoft.EntityFrameworkCore;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Repositories;
using Microsoft.AspNetCore.Http;
using TicketShopProject.Data.Models;
//using DrinkAndGo.Data.Interfaces;
//using DrinkAndGo.Data.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using System.Data.SqlClient;

namespace TicketShopProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
              services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //Authentication, Identity config

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            //DbInitializer.Seed(app);
          
            //app.UseIdentity();






















            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(" it is a development enviroment");
            //});



            //if  (env.IsProduction())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("it is production!");
            //});
        }
    }
}
