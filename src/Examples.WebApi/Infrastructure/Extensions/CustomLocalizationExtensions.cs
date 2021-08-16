using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.WebApi.Infrastructure.Extensions
{
    public static class CustomLocalizationExtensions
    {
        public static IServiceCollection UseCustomeLocalization(this IServiceCollection services, string resourcesPath)
        {
            // ----- Localization set Resource folder.
            services.AddLocalization(options => options.ResourcesPath = resourcesPath);

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            return services;
        }

        public static IApplicationBuilder UseCustomRequestLocalization(this IApplicationBuilder app)
        {
            // ----- Localization set request time cultures.
            var supportedCultures = new[] { "ja", "fr", "en-US" };
            app.UseRequestLocalization(new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures)
            );

            return app;
        }
    }
}