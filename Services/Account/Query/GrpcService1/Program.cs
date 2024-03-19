using Application.Abstractions;
using Application.UseCases.Events;
using Application.UseCases.Queries;
using Contracts.Services.Account;
using GrpcService1.Services;
using Infratructure.EventBus.DependencyInjection.Extensions;
using Infratructure.Projections;
using Infratructure.Projections.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddTransient<IInteractor<Query.GetListAccount, Projection.ListAccountUser>, GetAccountDetailsInteractor>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IPagedInteractor<Query.GetListAccountPaging, Projection.ListAccountUser>, GetListAccountInteractor>();
builder.Services.AddTransient<IInteractor<DomainEvent.AccountCreate>, ProjectAccountWhenPasswordChangesInteractor>();
builder.Services.AddTransient<IInteractor<DomainEvent.PasswordChange>, ProjectAccountItemWhenPasswordChangedInteractor>();
builder.Services.AddTransient<IInteractor<DomainEvent.AccountRemove>, ProjectAccountWhenRemoveAccountInteractor>();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
