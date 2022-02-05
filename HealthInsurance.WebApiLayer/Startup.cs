using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicManagers;
using HealthInsurance.DataAccessLayer.Abstract.IRepository;
using HealthInsurance.DataAccessLayer.Abstract.IUnitOfWorkRepository;
using HealthInsurance.DataAccessLayer.Concrete.EntityFramework.Context;
using HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfRepository;
using HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfUnitOfWorkRepository;
using HealthInsurance.InterfaceLayer.Abstract.IModelService;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.WebApiLayer
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
            #region Dependency Injections

            #region DbContext
            services.AddScoped<DbContext, BupaAcibademGraduationContext>();
            services.AddDbContext<BupaAcibademGraduationContext>(DbContextOptionsBuilder =>
            {
                DbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                    SqlServerDbContextOptionsBuilder =>
                    {
                        SqlServerDbContextOptionsBuilder.MigrationsAssembly("Northwind.DataAccessLayer");
                    });
            });
            #endregion

            #region ServiceSection
            services.AddScoped<ICardService, CardManager>();
            services.AddScoped<ICorporateCostemerService, CorporateCostemerManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IIndividualCustomerService, IndividualCustomerManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IProductService, ProductManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<ICardRepository, EfCardRepository>();
            services.AddScoped<ICorporateCostemerRepository, EfCorporateCostemerRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<IIndividualCustomerRepository, EfIndividualCustomerRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IPaymentRepository, EfPaymentRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWorkRepository, EfUnitOfWorkRepository>();
            #endregion

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthInsurance.WebApiLayer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthInsurance.WebApiLayer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
