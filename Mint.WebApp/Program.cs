using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.Configure<FormOptions>(x =>
{
    x.BufferBody = true;
    x.ValueCountLimit = int.MaxValue;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UsePathBase(new PathString("/api"));
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
