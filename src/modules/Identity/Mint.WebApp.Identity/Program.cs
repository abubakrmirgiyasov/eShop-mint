using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Identity.Lib.Repositories;
using Mint.Identity.Lib.Repositories.Interfaces;
using Mint.Identity.Lib.Services;
using Mint.Identity.Lib.Services.Interfaces;
using Mint.Infrastructure.MessageBrokers;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((cors) => cors.AddPolicy(MyAllowSpecificOrigins, policy =>
{
    policy.WithOrigins("http://127.0.0.1:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
}));

var brokerSettings = builder.Configuration.GetSection("MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();
builder.Services.AddMessageBusSender<User>(brokerOptions);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddHostedService<MessageBrokerBackgroundService<User>>();

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

app.UseCors(MyAllowSpecificOrigins);

app.Run();
