using Mint.Domain.Common;
using Mint.Infrastructure.Middlewares;
using Mint.WebApp.StorageCloud.Services;
using Mint.WebApp.StorageCloud.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettings);

builder.Services.AddScoped<MinioClientConnection>();
builder.Services.AddScoped<IStorageCloudService, StorageCloudService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
