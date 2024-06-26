using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.WebApp.Email.Services;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettings);

//var brokerSettings = builder.Configuration.GetSection("MessageBroker");
//var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();

builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddMessageBusSender<User>(brokerOptions);
//builder.Services.AddMessageBusReceiver<User>(brokerOptions);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddHostedService<MessageBrokerBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
