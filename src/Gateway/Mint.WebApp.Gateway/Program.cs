using Microsoft.AspNetCore.Http.Features;
using Mint.WebApp;
using Mint.WebApp.Extensions;
using Mint.WebApp.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("Ocelot");
var appSettings = config.Get<AppSettings>();

builder.Services.AddOcelot()
    .AddDelegatingHandler<DebuggingHandler>(true);

builder.Services.PostFileConfigure(appSettings!, builder);

builder.Services.Configure<FormOptions>(x =>
{
    x.BufferBody = true;
    x.ValueCountLimit = int.MaxValue;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UsePathBase(new PathString("/api"));
app.UseRouting();

app.UseWebSockets();
app.UseOcelot().Wait();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
