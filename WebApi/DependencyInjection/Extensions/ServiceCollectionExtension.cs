using Contracts.Services.Account;
using FluentValidation;
using MassTransit;
using Microsoft.OpenApi.Models;
using WebApi.Controllers.Account.Validator;

namespace WebApi.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigurationMasstransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<Command.CreateAccount>, CreateAccountValidator>();
            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });
            return services;
        }
    }
}
