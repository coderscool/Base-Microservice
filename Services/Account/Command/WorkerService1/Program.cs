using Application.Abstractions;
using Application.Abstractions.Gateways;
using Application.Services;
using Application.UseCases;
using Contracts.Services.Account;
using Infrastructure.MessageBus;
using Infrastructure.MessageBus.DependencyInjection.Extensions;
using Infratructure.EventStore;
using Infratructure.EventStore.DependencyInjection.Extensions;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddConfigurationMasstransit();

    services.AddTransient<IInteractor<Command.CreateAccount>, AddAccountInteractor>();

    services.AddTransient<IInteractor<Command.ChangePassword>, ChangePasswordInteractor>();

    services.AddTransient<IInteractor<Command.DeleteAccount>, RemoveAccountInteractor>();

    services.AddTransient<IApplicationService, ApplicationService>();

    services.AddTransient<IEventStoreGateway, EventStoreGateway>();

    services.AddTransient<IEventBusGateway, EventBusGateway>();

    services.AddConfigurationStoreEvent();

});

using var host = builder.Build();

try
{
    var environment = host.Services.GetRequiredService<IHostEnvironment>();

    if (environment.IsDevelopment() || environment.IsStaging())
    {
        //await using var scope = host.Services.CreateAsyncScope();
        //await using var dbContext = scope.ServiceProvider.GetRequiredService<EventStoreDbContext>();
        //await dbContext.Database.MigrateAsync();
        //await dbContext.Database.EnsureCreatedAsync();
    }

    await host.RunAsync();
}
catch (Exception ex)
{
    await host.StopAsync();
}
