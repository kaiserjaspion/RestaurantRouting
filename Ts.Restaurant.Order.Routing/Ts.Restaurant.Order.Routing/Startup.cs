using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Contexts;
using Ts.Restaurant.Order.Routing.Mapper;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Messenger;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Models;
using Ts.Restaurant.Order.Routing.Services;
using VueCliMiddleware;
using Ts.Restaurant.Order.Routing.Helpers;

namespace Ts.Restaurant.Order.Routing
{
    public class Startup
    {
        AutoMapperConfig AutoMapperConfig { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RabbitOptions>(Configuration.GetSection("RabbitMQ"));
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //            builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //    );
            //});

            AutoMapperConfig = new AutoMapperConfig(services);
            services.AddControllers();

            services.AddDbContext<KitchenContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString"]));

            services.AddSingleton(services.BuildServiceProvider()
                       .GetService<KitchenContext>());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/dist";
            });

            services.AddSwaggerGen();
            services.AddSingleton<IMessenger, Messenger>();
            services.AddSingleton<IOrderingService,OrderingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseCors();
            }
            app.UseHsts();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Routing Order Routing {env.EnvironmentName} - {GetType().Assembly.GetName().Version.ToString()}");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if (env.IsDevelopment())
                {
                    spa.UseVueDevelopmentServer();
                }
            });
        }
    }
}
