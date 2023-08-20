using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Repositories.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Interfaces;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var identitySettings = builder.Configuration.GetSection("IdentitySettings");
builder.Services.Configure<IdentitySettings>(identitySettings);

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
