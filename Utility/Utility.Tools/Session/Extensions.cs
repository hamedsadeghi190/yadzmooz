using Microsoft.Extensions.DependencyInjection;

namespace Utility.Tools.Session
{
    public static class Extensions
    {
        public static void AddSession(this IServiceCollection services)
        {
            services.AddSession();
        }
    }
}
