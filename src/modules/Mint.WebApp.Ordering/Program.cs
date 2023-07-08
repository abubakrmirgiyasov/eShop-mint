var builder = WebApplication.CreateBuilder(args);

//var brokers = builder.Configuration.GetSection("MessageBroker");
//var appSettings = brokers.Get<MessageBrokerOptions>();
//builder.Services.AddStorageModule(appSettings!);
//builder.Services.AddMessageBusReceiver<Order>(appSettings);

//builder.Services.AddHostedServicesStorageModule();

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
