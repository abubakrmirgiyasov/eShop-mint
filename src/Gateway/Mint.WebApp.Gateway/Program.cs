using Mint.Infrastructure.Middlewares;
using Mint.WebApp.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("OcelotJson\\ocelotSettings.json", false, true);
builder.Services.AddOcelot(builder.Configuration).AddDelegatingHandler<DebuggingHandler>(true);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseWebSockets();
app.UseOcelot().Wait();

//app.Map("health", () => new { message = "Gateway is running..." });
//app.MapControllers();

app.Run();
