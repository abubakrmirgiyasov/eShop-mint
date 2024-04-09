using Microsoft.EntityFrameworkCore;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Services;
using Mint.WebApp.Identity.Application.Operations.Repositories;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);

var brokerSettings = builder.Configuration.GetSection("MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();
builder.Services.AddMessageBusSender<User>(brokerOptions);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

//builder.Services.AddScoped<IJwtService, JwtService>();
//builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
