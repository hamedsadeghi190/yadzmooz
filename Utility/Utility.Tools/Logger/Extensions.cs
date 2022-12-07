using Microsoft.Extensions.DependencyInjection;

namespace Utility.Tools.Logger
{
    public static class Extensions
    {
        public static void AddLogger(this IServiceCollection services)
        {
            //services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
