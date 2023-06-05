using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.MessageBrokers.Models;
using Mint.Infrastructure.Repositories;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.Infrastructure.Services;
using Mint.WebApp.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var options = new MessageBrokerOptions();
builder.Configuration.Bind(options);

var settings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(settings);

//var brokers = builder.Configuration.GetSection("MessageBroker");
//builder.Services.Configure<MessageBrokerOptions>(brokers);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

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

builder.Services.AddStorageModule(options);
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

app.MapHealthChecks("/healthz");
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
