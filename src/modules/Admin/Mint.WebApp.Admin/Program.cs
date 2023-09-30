using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.Infrastructure.Redis;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Repositories;
using Mint.WebApp.Admin.Repositories.Interfaces;
using Mint.WebApp.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

var redis = builder.Configuration.GetSection(nameof(RedisSettings));
builder.Services.Configure<RedisSettings>(redis);

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<RedisClient>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IDistributedCacheManager, RedisCacheManager>();

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
