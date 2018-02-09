using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
//using TicketShopProject.Data;
//using Microsoft.EntityFrameworkCore;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Mocks;
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
        //public Startup(IHostingEnvironment hostingEnvironment)
        ////{
        ////    _configurationRoot = new ConfigurationBuilder()
        ////        .SetBasePath(hostingEnvironment.ContentRootPath)
        ////        .AddJsonFile("appsettings.json")
        ////        .Build();
        //}
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddTransient<ITicketRepository, MockTicketRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.UseSession();
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
