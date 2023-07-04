using Mint.WebApp.Email.Interfaces;
using Mint.WebApp.Email.Repositories;
using Mint.WebApp.Email.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
