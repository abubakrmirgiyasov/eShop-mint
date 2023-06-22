using Mint.WebApp.Telegram.WebHook.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().Build();

app.Configure();
app.Run();
