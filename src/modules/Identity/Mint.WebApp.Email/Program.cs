using Mint.WebApp.Email.Common;
using Mint.WebApp.Email.Interfaces;
using Mint.WebApp.Email.Repositories;
using Mint.WebApp.Email.Services;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("MailConfig");
builder.Services.Configure<MailConfig>(appSettings);

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

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
app.MapControllers();

app.Run();
