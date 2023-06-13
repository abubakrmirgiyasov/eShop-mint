using Mint.Infrastructure.MessageBrokers;
using Mint.WebApp.Ordering.Infrastructure;
using Mint.WebApp.Ordering.Infrastructure.Repositories;
using Mint.WebApp.Ordering.Infrastructure.Services;
using Mint.WebApp.Ordering.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("MessageBroker");
var appSettings = config.Get<MessageBrokerOptions>();

MongoDbPersistence.Configure();

builder.Services.AddMessageBusReceiver<Test>(appSettings);
builder.Services.AddHostedService<MessageBrokerBackgroundService>();

builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//builder.Services.AddCron<MessageBusReceiverBackgroundService>(options =>
//{
//    options.TimeZone = TimeZoneInfo.Local;
//    options.CronExpression = @"*/1 * * * *";
//});

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
