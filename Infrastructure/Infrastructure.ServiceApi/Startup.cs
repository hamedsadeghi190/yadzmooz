using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Utility.General;
using Utility.Tools;
using Utility.Tools.Auth;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;
using Utility.Tools.WebSocket.New;
using static Utility.Tools.General.Agent;

using Infrastructure.Mongo;

namespace Infrastructure.ServiceApi
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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Configuration.GetSection<AdminSettings>();

            //services.AddApplicationServices();
            //services.AddMongoRepositories();

            //services.AddSwager();

            services
             .AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy",
                     builder => builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     );

                 options.AddPolicy("signalr",
                     builder => builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()

                     .AllowCredentials()
                     .SetIsOriginAllowed(hostName => true));
             });
            services.AddControllers(options =>
            {
                //options.Filters.Add(typeof(LogFilterAttribute));
                //options.Filters.Add(typeof(CustomExceptionFilter));
                //options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
                options.EnableEndpointRouting = false;
            }).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });
            //services.AddJwt(Configuration);
            //services.AddScoped<IEncrypter, Encrypter>();
            //services.AddScoped<INotification, RahyabService>();
            //services.AddScoped<FireBase>();
            //services.AddScoped<DeliveryFireBase>();
            //services.AddScoped<ServiceResolver>(serviceProvider => key =>
            //{
            //    switch (key)
            //    {
            //        case "normal":
            //            return serviceProvider.GetService<FireBase>();
            //        case "delivery":
            //            return serviceProvider.GetService<DeliveryFireBase>();
            //        default:
            //            return serviceProvider.GetService<FireBase>();
            //    }
            //});

            //services.AddSingleton<ICustomWebSocketFactory, CustomWebSocketFactory>();
            //services.AddSingleton<ICustomWebSocketMessageHandler, CustomWebSocketMessageHandler>();

            //services.AddSingleton<IEventHandler<ActivityCreated>, ActivityCreatedHandler>();
            //services.AddRabbitMq(Configuration);

            //services.AddScoped<IHandleRabbit, HandleRabbit>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureSwager();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();
        }
    }
}
