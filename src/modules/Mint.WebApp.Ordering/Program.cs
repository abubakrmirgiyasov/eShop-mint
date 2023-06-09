using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.MongoDb.Interfaces;
using Mint.Infrastructure.MongoDb.Services;
using Mint.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

var brokers = builder.Configuration.GetSection("MessageBroker");
var appSettings = brokers.Get<MessageBrokerOptions>();
builder.Services.AddStorageModule(appSettings!);
builder.Services.AddMessageBusReceiver<Order>(appSettings);

var settings = builder.Configuration.GetSection("MongoDbSettings");
builder.Services.Configure<MongoDbSettings>(settings);

builder.Services.AddHostedServicesStorageModule();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
