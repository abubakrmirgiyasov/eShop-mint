using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Middlewares;
using Mint.Infrastructure.Repositories.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.WebApp.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Mint.WebApp.Extensions.Identities;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettings);

builder.Configuration.AddJsonFile("OcelotJson\\ocelotSettings.json", false, true);
builder.Services.AddOcelot(builder.Configuration).AddDelegatingHandler<DebuggingHandler>(true);

var brokerSettings = builder.Configuration.GetSection("AppSettings:MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();
builder.Services.AddMessageBusSender<User>(brokerOptions);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddAuthenticationServices();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseWebSockets();
app.UseOcelot().Wait();

app.Run();
