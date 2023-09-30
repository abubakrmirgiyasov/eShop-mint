using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Repositories.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var identitySettings = builder.Configuration.GetSection("IdentitySettings");
builder.Services.Configure<IdentitySettings>(identitySettings);

builder.Configuration.AddJsonFile("OcelotJson\\ocelotSettings.json", false, true);
builder.Services.AddOcelot(builder.Configuration).AddDelegatingHandler<DebuggingHandler>(true);

var brokerSettings = builder.Configuration.GetSection("MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();
builder.Services.AddMessageBusSender<User>(brokerOptions);

var redisSettings = builder.Configuration.GetSection("RedisSettings");
builder.Services.Configure<RedisSettings>(redisSettings);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseWebSockets();
app.UseOcelot().Wait();

app.Run();
