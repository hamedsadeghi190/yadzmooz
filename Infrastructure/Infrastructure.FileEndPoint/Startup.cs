using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Entities.GlobalSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Utility.Tools;
using Utility.Tools.Auth;
using Utility.Tools.Exceptions;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;
using Utility.Tools.Cors;
using Utility.Tools.MVC;
using Utility.Tools.WebSocket.New;
using Core.Entities;
using Utility.Tools.General;
using System.IO;
using Infrastructure.Mongo;
using Core.Mongo.Contracts;
using Core.Entities.Mongo.Dto.Countries;
using Core.Entities.Mongo;
using Utility.Tools.Mongo;
using Utility.Tools.Elastic;
using Core.Entities.Mongo.Enums;

namespace Infrastructure.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.GetSection<AdminSettings>();
            services.AddApplicationServices();
            services.AddMongoRepositories();
            services.AddSwager();

            services.ConfigureCors("CorsPolicy");

            services.AddControllers(options =>
            {
                //options.Filters.Add(typeof(LogFilterAttribute));
                options.Filters.Add(typeof(CustomExceptionFilter));
                //options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
                options.EnableEndpointRouting = false;
            }).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });

            //services.AddSingleton<ICustomWebSocketFactory, CustomWebSocketFactory>();
            //services.AddSingleton<ICustomWebSocketMessageHandler, CustomWebSocketMessageHandler>();
            services.AddMongo(Configuration);
            services.AddJwt(Configuration);
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFireBase, FireBase>();
            services.AddElastic(Configuration);



        }

      

        

        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwager();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();



            //var webSocketOptions = new WebSocketOptions()
            //{
            //    KeepAliveInterval = TimeSpan.FromSeconds(12000),
            //    ReceiveBufferSize = 4 * 1024
            //};

            //app.UseWebSockets(webSocketOptions);
            //app.UseCustomWebSocketManager();

        }
        
    }
}
