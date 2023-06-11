using Microsoft.OpenApi.Models;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var config = builder.Configuration.GetSection("MessageBroker");
//var appSettings = config.Get<MessageBrokerOptions>();

//builder.Services.AddMessageBusReceiver<Test>(appSettings);
//builder.Services.AddHostedService<MessageBrokerBackgroundService>();

builder.Services.AddCron<MessageBusReceiverBackgroundService>(options =>
{
    options.TimeZone = TimeZoneInfo.Local;
    options.CronExpression = @"*/1 * * * *";
});

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
