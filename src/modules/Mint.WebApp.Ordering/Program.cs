using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("MessageBroker");
var appSettings = config.Get<MessageBrokerOptions>();

builder.Services.AddMessageBusReceiver<Test>(appSettings);
builder.Services.AddHostedService<MessageBrokerBackgroundService>();

builder.Services.AddCron<MessageBusReceiverBackgroundService>(options =>
{
    options.TimeZone = TimeZoneInfo.Local;
    options.CronExpression = @"*/1 * * * *";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
