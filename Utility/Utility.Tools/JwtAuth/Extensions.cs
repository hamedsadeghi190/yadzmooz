using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Auth
{
    public static class Extensions
    {
        public static void AddJwt(this IServiceCollection services,IConfiguration config)
        {            
            var options = new JwtOptions();
            var section = config.GetSection("jwt");
            section.Bind(options);
            services.Configure<JwtOptions>(section);
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;                   
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidIssuer = options.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
                    };
                });
        }
    }
}
