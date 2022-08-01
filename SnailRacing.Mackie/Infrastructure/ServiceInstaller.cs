using DSharpPlus;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SnailRacing.Mackie.Domain;
using SnailRacing.Mackie.Handlers.TeamHandlers;
using SnailRacing.Mackie.Models;

namespace SnailRacing.Mackie.Infrastructure
{
    internal static class ServiceInstaller
    {
        public static ServiceProvider ConfigureServices(AppConfig appConfig, DiscordClient discord)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(l => l.AddSerilog())
                .AddSingleton(appConfig)
                .AddValidatorsFromAssembly(typeof(ServiceInstaller).Assembly)
                .AddMediatR(typeof(TeamCreateHandler).Assembly)
                .AddScoped<AppDbContext>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddSingleton(discord)
                .AddTransient<IDiscordRepository, DiscordRepository>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
