using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using UseCases.DataStorePluginInterfaces;
using WebApp.Data;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCases;
using UseCases.CategoriesUseCases.UseCaseInterfaces;
using UseCases.ProductsUseCases.UseCaseInterfaces;
using UseCases.TransactionsUseCases.UseCaseInterfaces;
using UseCases.TransactionsUseCases;
using Plugins.DataStore.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UseCases.UsersUseCases;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();            

            services.AddDbContext<MarketContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthorization(options => 
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", new List<string> { "Admin" }));              
                options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", new List<string> { "Cashier" }));
            });

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ITransacionsRepository, TransactionsRepository>();

            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

            services.AddTransient<IViewProductsUseCase, ViewProductsUseCases>();
            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IViewProductsByCategoryUseCase, ViewProductsByCategoryUseCase>();
            services.AddTransient<ISellProductUseCase, SellProductUseCase>();

            services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
            services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();

            services.AddTransient<IGetCashiersUseCase, GetCashiersUseCase>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
