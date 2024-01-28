using Mint.Domain.Common;
using Mint.Infrastructure.Middlewares;
using Mint.WebApp.StorageCloud.Services;
using Mint.WebApp.StorageCloud.Services.Interfaces;
using Mint.WebApp.Extensions.Identities;
using Mint.Infrastructure.MessageBrokers;
using Mint.WebApp.StorageCloud.Models;
using Mint.Domain.DTO_s.MessageBroker;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = config.Get<AppSettings>();
builder.Services.Configure<AppSettings>(config);

builder.Services.AddMessageBusSender<BrokerDataDto>(appSettings?.MessageBroker);
builder.Services.AddMessageBusSender<UserImage>(appSettings?.MessageBroker);
builder.Services.AddMessageBusReceiver<StorageCloudDto>(appSettings?.MessageBroker);

builder.Services.AddHostedService<MessageBrokerBackgroundService<StorageCloudDto>>();

builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<MinioClientConnection>();
builder.Services.AddScoped<IStorageCloudService, StorageCloudService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtConfiguration(appSettings!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
