using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Utility.Tools.Auth;
using Utility.Tools.Notification;
using Core.ApplicationServices;
using Utility.Tools.SMS.Rahyab;
using Utility.Tools;
using System.Net.Sockets;
using System.Net.WebSockets;
using Infrastructure.Mongo;
using Utility.Tools.Mongo;
using Core.Mongo.Contracts;
using Utility.Tools.General;
using Core.Entities.Mongo.Enums;
using RestSharp;
using System.Text;
using Core.Entities.Mongo.Dto;

namespace ConsoleCore
{
    class Program
    {
        public static IUnitOfWork Iunit { get; private set; }
        public static INotification Notification { get; private set; }
        public static IEncrypter Encrypter { get; private set; }
        public static IJwtHandler JwtHandler { get; private set; }
        public static IFireBase Firebase { get; private set; }
        public static INewFireBase NewFirebase { get; private set; }
        public static IConfiguration Configuration { get; set; }



        static async Task Main()
        {

            Config();
            //var data = Agent.GenerateQrCode(Guid.NewGuid());
            //var obj = FileTypes.Image;

            ////Marshal.Copy(stream, bytes, 0, (int)data.Size);


            ////var res = Api.PostRequest(Agent.ToJson(obj), "http://localhost:53203/Document/SendDocument", data, "");
            //var res = Api.PostRequest(Agent.ToJson(obj), "http://file.makanavenue.com/Document/SendDocument", data, "");


            //StartPay pay = new StartPay(Iunit, Configuration);

            //var dto = new StartPayDto
            //{
            //    Amount = 300,
            //    Descripion = "test",
            //    Email = "miad@gmail.com",
            //    Mobile = "60188725249",
            //    Name = "miad"
            //};

            //var url = pay.Execute(dto);

            //GetGeneralStoreReport get = new GetGeneralStoreReport(Iunit);
            //var dto = new GetGeneralStoreReportDto { StoreId = "19ad27b6-c247-4805-bf33-a3c7f1b58484".ToGuid() };
            //get.Execute(dto);

            //var client = new RestClient("https://www.billplz-sandbox.com/api/v3/bills?collection_id=lhjd2vei&email=somebody@gmail.com&mobile=60121234567&name=JohnDoe&amount=300&callback_url=http://google.com&description=AnydescriptionforBillpayment");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", "Basic Y2Q5NGFmODgtM2FkMS00OWJhLTg0OWEtYmNjMWFhNmNkNjY4Og==");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);



            //List<string> str = new List<string>();
            //var n = new AddNotificationDto
            //{
            //    Description = "ss",
            //    Link = "sds",
            //    Title = "sdsd",
            //    RoleId = 2
            //};
            //str.Add("c-u3OBFeTlq9kOpKr4c9Px:APA91bFf0fd8HG1m8zCbQOBnfj9uOSb2Ln2YTy5sckQZ5TD8tLTnAirjqiONE3booD8lZKDFf9F4YbaPKWXxBaWQXjPzorHevMgNdE55QDLLzX8P4qEf0agWZPR7XKipHmtUeOOFD1Ay");

            //Firebase.SendNotification(str, n,); 



            //SendActivationCode sendActivationCode = new SendActivationCode(Iunit, Notification);
            //var data = new { action = "Play", userId = 5 };
            //sendActivationCode.Execute(new SendActivationCodeDto { Mobile = "+989338006252" });
            //List<string> str = new List<string>();
            //str.Add("dWlcksuaRWugXYfb4c15gv:APA91bG--KreErZtKI7tHUJV6onl0OEdDr3YnU_8AYkbJTIJK83DihxkWvHSKwz0oKR9tCkByJpTPbFc9-d9KAd-Hl4N04eu8SQ-VyTXr78HaqPhyZF7rgPXX6sxpNV_NYNtikzcOdWQ");
            //string[] terms = str.ToArray();
            //NewFirebase.SendNotification(terms, "miad", "ali", data);
            //var a = Agent.GetSerialKeyAlphaNumaric(6);
            //Console.WriteLine(a);

            Console.ReadKey();

        }



        public static void Config()
        {
            ServiceCollection service = new ServiceCollection();
            var builder = new ConfigurationBuilder().SetBasePath(@"D:\Projects\Food\Food\Infrastructure\Infrastructure.CustomerEndPoint").AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            Configuration = builder.Build();

            service.AddSingleton<IConfiguration>(builder.Build());
            service.AddMongo(Configuration);

            service.ConfigureServices(Configuration);
            service.AddApplicationServices();

            var provider = service.BuildServiceProvider();
            Iunit = provider.GetService<IUnitOfWork>();
            Encrypter = provider.GetService<IEncrypter>();
            Notification = provider.GetService<INotification>();
            JwtHandler = provider.GetService<IJwtHandler>();
            Firebase = provider.GetService<IFireBase>();
            NewFirebase = provider.GetService<INewFireBase>();
        }


    }






}
