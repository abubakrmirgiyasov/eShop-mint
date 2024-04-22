using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.Infrastructure.Middlewares;
using Mint.WebApp.Client;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetSection(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection.Value));

var configuration = builder.Configuration.GetSection("AppSettings");
var appSettings = configuration.Get<AppSettings>();
builder.Services.Configure<AppSettings>(configuration);

builder.Services.ClientServicesCollection(appSettings);

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

app.UseExceptionHandler();

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Map("health", () => new { message = "Client App is running..." });
app.MapControllers();

app.Run();
