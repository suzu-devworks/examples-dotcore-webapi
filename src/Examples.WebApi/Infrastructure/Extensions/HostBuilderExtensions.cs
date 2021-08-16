using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Examples.WebApi.Infrastructure.Extensions
{
    static class HostBuilderExtensions
    {
        public static IHostBuilder UseCustomLogging(this IHostBuilder builder)
        {
            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                logging.AddNLog();
            });

            return builder;
        }

    }
}