using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.GlobalSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

namespace Utility.Tools.MVC
{
    public static class Extensions
    {
        public static void ConfigureMVC(this IServiceCollection services)
        {
            
        }
    }
}
