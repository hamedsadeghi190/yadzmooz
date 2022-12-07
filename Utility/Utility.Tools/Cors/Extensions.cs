using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Cors
{
    public static class Extensions
    {
        public static void ConfigureCors(this IServiceCollection services,string Name)
        {
            services.AddCors(options =>
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
        }
    }
}
