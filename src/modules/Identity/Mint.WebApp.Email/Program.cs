using Mint.Domain.Models.Identity;
using Mint.Infrastructure.MessageBrokers;
using Mint.WebApp.Email.Common;
using Mint.WebApp.Email.Interfaces;
using Mint.WebApp.Email.Repositories;
using Mint.WebApp.Email.Services;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((cors) => cors.AddPolicy(MyAllowSpecificOrigins, policy =>
{
    policy.WithOrigins("http://127.0.0.1:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
}));

var appSettings = builder.Configuration.GetSection("MailConfig");
builder.Services.Configure<MailConfig>(appSettings);

var brokerSettings = builder.Configuration.GetSection("MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

builder.Services.AddMessageBusSender<User>(brokerOptions);
builder.Services.AddMessageBusReceiver<User>(brokerOptions);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<MessageBrokerBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
