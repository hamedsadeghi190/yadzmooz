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
using Utility.Tools.Mongo;
using Infrastructure.Mongo;
using Core.Mongo.Contracts;
using Core.Entities.Mongo.Dto.Countries;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Enums;
using ServiceReference1;
using Microsoft.AspNetCore.HttpOverrides;


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
            //Configuration.GetSection<PaySettings>();
            services.AddApplicationServices();
            services.AddMongoRepositories();
            services.AddSwager();


            services.ConfigureCors("CorsPolicy");

            services.AddControllersWithViews(options =>
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


             
            services.AddMongo(Configuration);
             services.AddJwt(Configuration);
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<INotification, MySMSService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFireBase, FireBase>();
            services.AddScoped<INewFireBase, NewFireBase>();
            //services.AddScoped<MongoContext>();

            services.AddTransient<IPaymentGateway, PaymentGatewayClient>();


            //Seed(services);


        }

        private void Seed(IServiceCollection services)
        {
            InsertUsers(services);
            //InsertCountries(services);
            //InsertCategories(services);
        }



        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });
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
        private void InsertCountries(IServiceCollection services)
        {
            List<CountryJson> resul = new List<CountryJson>();
            using (var str = new StreamReader(@"Data.json"))
            {
                resul = Agent.FromJson<List<CountryJson>>(str.ReadToEnd());
            }



            List<Country> count = new List<Country>();
            List<Province> prov = new List<Province>();
            List<Core.Entities.Mongo.City> cities = new List<Core.Entities.Mongo.City>();

            resul.ForEach(p =>
            {
                Country cont = new Country { Id = p.id, Name = p.name };
                List<Province> tmpPro = new List<Province>();
                p.states.ForEach(q =>
                {
                    Province pr = new Province { Name = q.name, CountryId = p.id, Id = q.id };
                    List<Core.Entities.Mongo.City> tmpCities = new List<Core.Entities.Mongo.City>();
                    q.cities.ForEach(t =>
                    {
                        cities.Add(new Core.Entities.Mongo.City { Name = t.name, ProvinceId = q.id, Id = t.id, CountryId = cont.Id, CountryName = cont.Name, ProvinceName = pr.Name });
                        tmpCities.Add(new Core.Entities.Mongo.City { Name = t.name, ProvinceId = q.id, Id = t.id, CountryId = cont.Id, CountryName = cont.Name, ProvinceName = pr.Name });
                    });
                    pr.CountryName = cont.Name;
                    pr.Cities = tmpCities;
                    prov.Add(pr);
                    tmpPro.Add(pr);
                });
                cont.Provinces = tmpPro.Select(t => new ShortProvince { Cities = t.Cities.Select(r => new ShortCity { Id = r.Id, Name = r.Name }).ToList(), Id = t.Id, Name = t.Name }).ToList();
                count.Add(cont);

            });
            var provider = services.BuildServiceProvider();
            var unit = provider.GetService<IUnitOfWork>();
            //unit.Countries.AddRange(count);
            //unit.Provinces.AddRange(prov);
            //unit.Cities.AddRange(cities);
            Console.WriteLine("*************************");
        }

        private void InsertUsers(IServiceCollection services)
        {




            //User storUser = new User 
            //{
            //    UserName = "store",
            //    CreatedAt = DateTime.Now.ToUnix(),
            //    Name = "store",
            //    Status = 3
            //};
            //storUser.SetPassword("123456");








            

           
            var provider = services.BuildServiceProvider();
            var unit = provider.GetService<IUnitOfWork>();
            //unit.Users.Insert(adminUser);
            //unit.Users.Insert(storUser);
            //unit.Updates.Insert(up);
            Console.WriteLine("*************************");
        }
    }
}


