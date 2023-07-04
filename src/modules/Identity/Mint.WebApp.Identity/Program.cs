using Mint.Domain.Common;
using Mint.Infrastructure.MongoDb.Interfaces;
using Mint.Infrastructure.MongoDb.Services;
using Mint.WebApp.Identity.Repositories;

var builder = WebApplication.CreateBuilder(args);

//var brokers = builder.Configuration
//    .GetSection("MessageBroker")
//    .Get<MessageBrokerOptions>();
//builder.Services.AddStorageModule(brokers!);
//

var mongoDb = builder.Configuration.GetSection("MongoDbSettings");
builder.Services.Configure<MongoDbSettings>(mongoDb);

//builder.Services.AddHostedServicesStorageModule();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<AuthenticationRepository>();

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
