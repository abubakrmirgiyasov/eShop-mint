using Mint.Domain.Models.Identity;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Repositories.Email;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Email.Common;
using Mint.WebApp.Email.Services;

var builder = WebApplication.CreateBuilder(args);

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

app.Run();
