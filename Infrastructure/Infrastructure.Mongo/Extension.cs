using Core.Entities;
using Core.Entities.GlobalSettings;
using Core.Mongo.Contracts;
using Enums;
using Infrastructure.Mongo;
using Infrastructure.Mongo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Utility.Tools;
using Utility.Tools.Auth;
using Utility.Tools.General;
using Utility.Tools.Notification;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools.Swager;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Infrastructure.Mongo
{
    public static class Extension
    {
        
        public static void AddMongoRepositories(this IServiceCollection services)
        {
            
            var mongoRepositpryType = typeof(IRepository).Assembly;
            var AllMongoRepositories = mongoRepositpryType.ExportedTypes 
               .Where(x => !x.Name.StartsWith("IRepository") && x.Name.Contains("Repository") && x.IsClass && x.IsPublic)
               .ToList();
            Console.WriteLine($"************* {AllMongoRepositories.Count} ************");
            foreach (var type in AllMongoRepositories)
            {
                //try
                //{
                    Console.WriteLine(type.Name);
                    services.AddScoped(type.GetInterface($"I{type.Name}"), type);
                //}
                //catch { }
            }
        }

        public static void ConfigureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            configuration.GetSection<AdminSettings>();            
            services.AddMongoRepositories();
            services.AddSwager();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
            //services.AddMvc(options =>
            //{
            //    //options.Filters.Add(typeof(LogFilterAttribute));
            //    options.Filters.Add(typeof(CustomExceptionFilter));
            //    //options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
            //}).AddSessionStateTempDataProvider().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddJwt(configuration);
            //configuration.GetSection<RahyabParameters>();
            //services.AddDbContext<MainContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure.EndPoint")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, RahyabService>();

            //configuration.GetSection<RahyabParameters>();
            //services.AddJwt(configuration);

            services.AddScoped<IEncrypter, Encrypter>();

            services.AddScoped<INotification, RahyabService>();
            services.AddScoped<IFireBase, FireBase>();

        }
    }
}
