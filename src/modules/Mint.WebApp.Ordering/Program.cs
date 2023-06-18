using Microsoft.Extensions.Options;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Services;
using Mint.WebApp.Ordering.Common;
using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using Mint.WebApp.Ordering.Infrastructure.Services;
using Mint.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("MessageBroker");
var appSettings = config.Get<MessageBrokerOptions>();

builder.Services.AddMessageBusReceiver<Test>(appSettings);
builder.Services.AddHostedService<MessageBrokerBackgroundService>();

builder.Services.AddCron<MessageBusReceiverBackgroundService>(options =>
{
    options.TimeZone = TimeZoneInfo.Local;
    options.CronExpression = @"*/1 * * * *";
});

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(options => options.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

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
