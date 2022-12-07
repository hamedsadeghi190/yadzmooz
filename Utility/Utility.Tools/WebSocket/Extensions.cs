using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.WebSockets;

namespace Utility.Tools.WebSocket
{
    public static class Extensions
    {
        //public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
        //                                                PathString path,
        //                                                WebSocketHandler handler)
        //{
        //    return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
        //}
        //public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        //{
        //    services.AddTransient<ConnectionManager>();

        //    foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
        //    {
        //        if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
        //        {
        //            services.AddSingleton(type);
        //        }
        //    }

        //    return services;
        //}

        public static IApplicationBuilder UseWebSocketHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketMiddleware>();
        }
    }
}
