using Autofac;
using Autofac.Extensions.DependencyInjection;
using Buisness.CouponService;
using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly("DataAccess");//ayn? db de farkl? migration klasorlerini ay?rmak için tan?mland? 1_31_22
                    });
            });

            //     services.AddEntityFramework().AddSqlServer().AddDbContext<MyDbContext>(
            //options =>
            //{
            //    var config = Configuration["Data:DefaultConnection:ConnectionString"];
            //    options.UseSqlServer(config);
            //});

            // code removed for brevity

            //services.AddSingleton<DataContext>();

            //services.AddSingleton<IRepository<>, Repository<>>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(Repository<>));
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            //services.AddSingleton<ICouponCodeService, CouponCodeService>();
            //services.AddSingleton<ILanguageService, LanguageService>();
            //services.AddSingleton<ILocalizationService, LocalizationService>();
            //services.AddSingleton<INewsAgencyCategoryService, NewsAgencyCategoryService>();
            //services.AddSingleton<INewsAgencyService, NewsAgencyService>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
               var builder = new ContainerBuilder();


            builder.RegisterAssemblyTypes(Assembly.Load("DataAccess"))
         .Where(t => t.Name.EndsWith("Service"))
         .AsImplementedInterfaces()
         .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("DataAccess"))
                  .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Manager"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("Buisness"))
                     .Where(t => t.Name.EndsWith("Service"))
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope();

            builder.RegisterType<DataContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).InstancePerLifetimeScope().As(typeof(IRepository<>));


            builder.Populate(services);
            var appContainer = builder.Build();
            return new AutofacServiceProvider(appContainer);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:36772").AllowAnyHeader());

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
