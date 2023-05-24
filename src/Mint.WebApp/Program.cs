using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.Infrastructure.Services;
using Mint.WebApp.Extensions;
using Mint.WebApp.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(settings);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

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

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IManufactureRepository, ManufactureRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

//builder.Services.AddHealthChecks();
    //.AddCheck<HealthCheckMiddleware>("Test", tags: new[] { "health" });

//builder.Services
//    .AddHealthChecksUI()
//    .AddInMemoryStorage();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.MapHealthChecksUI();
//app.HealthChecksRoutes();

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
