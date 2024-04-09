using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.Infrastructure.Middlewares;
using Mint.WebApp.Admin.Identity;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetSection(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection.Value));

var config = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = config.Get<AppSettings>();
builder.Services.Configure<AppSettings>(config);

builder.Services.AdminIdentityServicesCollection(appSettings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Map("health", () => new { message = "Admin Identity is running..." });
app.MapControllers();

app.Run();
