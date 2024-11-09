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
using Warehouse.DAL.Abstract;
using Warehouse.Domain.Services;
using Warehouse.Domain.Services.Abstract;
using Warehouse.DAL;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;


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

            // �������� ����������
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

            // ����� ����������, ��������� ��������� �������� ����� (endpoints) � �������� ��������� ��������
            app.UseEndpoints(endpoints =>
            {
                // ��������� ��������
                // name - ��� ��������
                // pattern - ������ �������, ����������, ��� ����� �������������� URL-������
                // { controller = Home}: ��� �����������.
                // { action = Index}: ��� ��������.
                // { id ?}: �������� `id` �������� ��������������(����������� `?`)
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // ���������� ������ ��������
                // ���������, ��� ���� URL ���������� � `/Product`, ��������� ��� �������� �, ��������, `id`
                // ������������� ���������� �� ��������� ��� `Product` � �������� �� ���������
                // ��� `Index`. ��� ��������� � URL `/Product` ����� ������� �������� `Index` ����������� `Product`.
                //endpoints.MapControllerRoute(
                //    name: "product",
                //    pattern: "Product/{action}/{id?}",
                //    defaults: new { controller = "Product", action = "Index" });
            });
        }
    }
}
