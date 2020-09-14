using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefactorThis.Data;
using RefactorThis.Data.Repositories;
using RefactorThis.Data.Repositories._Framework;
using RefactorThis.Framework.AutoMapper;
using RefactorThis.Service.Services.Product;
using RefactorThis.Service.Services.ProductOption;

namespace RefactorThis
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
            services.AddAutoMapper(config => config.AddMaps(new List<Assembly>
            {
                typeof(ProductProfile).Assembly
            }));

            services.AddMvc(opt => opt.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ProductContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Default")));

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductOptionRepository, ProductOptionRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductOptionService, ProductOptionService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}