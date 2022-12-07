using Core.ApplicationServices;
using Core.Mongo.Contracts;
using Infrastructure.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Tools;
using Utility.Tools.Auth;
using Utility.Tools.Elastic;
using Utility.Tools.Exceptions;
using Utility.Tools.Mongo;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;
using Utility.Tools.Cors;
using Core.Entities.GlobalSettings;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.BillPay
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
            }).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });

            //services.AddSingleton<ICustomWebSocketFactory, CustomWebSocketFactory>();
            //services.AddSingleton<ICustomWebSocketMessageHandler, CustomWebSocketMessageHandler>();
            services.AddMongo(Configuration);
            services.AddJwt(Configuration);
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, RahyabService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
            services.AddScoped<IFireBase, FireBase>();
            services.AddScoped<INewFireBase, NewFireBase>();
            //services.AddScoped<MongoContext>();
            services.AddElastic(Configuration);

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
