using Microsoft.EntityFrameworkCore;
using Mint.Infrastructure;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Repositories;
using Mint.WebApp.Admin.Repositories.Interfaces;
using Mint.WebApp.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

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
