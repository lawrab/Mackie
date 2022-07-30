using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SnailRacing.Mackie.Handlers;
using SnailRacing.Mackie.Models;

namespace SnailRacing.Mackie.Infrastructure
{
    internal static class ServiceInstaller
    {
        public static ServiceProvider ConfigureServices(AppConfig appConfig)
        {
            return new ServiceCollection()
                .AddLogging(l => l.AddSerilog())
                .AddSingleton(appConfig)
                .AddValidatorsFromAssembly(typeof(ServiceInstaller).Assembly)
                .AddMediatR(typeof(TeamCreateHandler).Assembly)
                .BuildServiceProvider();
        }
    }
}
