using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.IISIntegration
{
    public static class Extensions
    {
        public static void AddIISIntegration(this IServiceCollection services,IConfiguration config)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}
