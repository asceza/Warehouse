using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Domain.Services;
using Warehouse.DAL;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;
using Warehouse.Domain.Contracts;


namespace Warehouse.WebUI
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
            services.AddControllersWithViews();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepositoryJSON>();

            // —оздание провайдера
            var serviceProvider = services.BuildServiceProvider();


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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // метод расширени€, добавл€ет поддержку конечных точек (endpoints) в конвейер обработки запросов
            app.UseEndpoints(endpoints =>
            {
                // настройка маршрута
                // name - им€ маршрута
                // pattern - строка шаблона, определ€ет, как будут обрабатыватьс€ URL-адреса
                // { controller = Home}: им€ контроллера.
                // { action = Index}: им€ действи€.
                // { id ?}: параметр `id` €вл€етс€ необ€зательным(обозначение `?`)
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // ƒобавление нового маршрута
                // указывает, что если URL начинаетс€ с `/Product`, последует им€ действи€ и, возможно, `id`
                // устанавливает контроллер по умолчанию как `Product` и действие по умолчанию
                // как `Index`. ѕри обращении к URL `/Product` будет вызвано действие `Index` контроллера `Product`.
                //endpoints.MapControllerRoute(
                //    name: "product",
                //    pattern: "Product/{action}/{id?}",
                //    defaults: new { controller = "Product", action = "Index" });
            });
        }
    }
}
