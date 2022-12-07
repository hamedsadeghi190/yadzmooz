using Core.ApplicationServices;
using Core.Entities;
using Core.Entities.GlobalSettings;
using Core.Mongo.Contracts;
using Enums;
using Infrastructure.Mongo;
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
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var applicationServiceType = typeof(IApplicationService).Assembly;
            var AllApplicationServices = applicationServiceType.ExportedTypes
               .Where(x => x.IsClass && x.IsPublic && x.FullName.Contains("ApplicationService")).ToList();
            foreach (var type in AllApplicationServices)
            {
                Console.WriteLine(type.Name);
                services.AddScoped(type.GetInterface($"I{type.Name}"), type);
            }
        }
        
    }
}
