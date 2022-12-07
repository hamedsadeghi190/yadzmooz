using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;

namespace Utility.Tools.SignalR
{
    public static class Extensions
    {
        
        public static void AddSignalR(this IServiceCollection service, IConfiguration config)
        {
            service.AddSignalR();
        }
        public static void UseSignalR(this IApplicationBuilder app)
        {
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<Chat>("/signal");
            //});
            
            app.UseSignalR(routes =>
            {
                routes.MapHub<Chat>("/signalr");
            });
        }
    }
}
