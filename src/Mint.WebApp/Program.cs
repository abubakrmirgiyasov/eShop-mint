using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.Infrastructure.HealthChekcs;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Repositories;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Extensions;
using Mint.WebApp.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(settings);

var config = builder.Configuration.GetSection("MessageBroker");
var brokers = config.Get<MessageBrokerOptions>();

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

var healthChecksBuilder = builder.Services
    .AddHealthChecks()
    .AddDbSqlServer(
        connectionString: connection!,
        healthQuery: "SELECT 1",
        name: "Sql Server",
        failureStatus: HealthStatus.Degraded)
    .AddHttp(
        uri: "https://localhost:44411/",
        name: "Identity Server",
        failureStatus: HealthStatus.Degraded);
builder.Services
    .AddHealthChecksUI(
        setupSettings: setup =>
        {
            setup.AddHealthCheckEndpoint("Basic Health Check", $"https://localhost:44411/healthz");
            setup.DisableDatabaseMigrations();
        })
    .AddInMemoryStorage();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.Configure<FormOptions>(option =>
{
    option.BufferBody = true;
    option.ValueCountLimit = int.MaxValue;
    option.ValueLengthLimit = int.MaxValue;
    option.MultipartBodyLengthLimit = int.MaxValue;
    option.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddStorageModule(brokers!);
builder.Services.AddHostServiceStorageModule();

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IManufactureRepository, ManufactureRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
    }
});
app.UseHealthChecksUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UsePathBase(new PathString("/api"));
app.UseRouting();

app.UseMiddleware<ExceptionMiddleWare>();
app.UseMiddleware<JwtMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
