using System;
using Microsoft.Extensions.DependencyInjection;
using Examples.WebApi.Application.Commands.LazyCommands;
using Examples.WebApi.Application.Repositories;

namespace Examples.WebApi.Application.Extensions
{
    public static class RocketControllerExtensions
    {
        public static IServiceCollection UseRocketRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<IRocketRepository, RocketRepository>();

            services.AddScoped<IGetRocketCommand, GetRocketCommand>();
            services.AddScoped(x => new Lazy<IGetRocketCommand>(
                () => x.GetRequiredService<IGetRocketCommand>()));

            services.AddScoped<ILaunchRocketCommand, LaunchRocketCommand>();
            services.AddScoped(x => new Lazy<ILaunchRocketCommand>(
                () => x.GetRequiredService<ILaunchRocketCommand>()));

            return services;
        }

    }
}