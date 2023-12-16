using Mint.WebApp.Extensions.Identities;
using Mint.WebApp.Extensions;
using Mint.Domain.Common;
using Mint.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettings);

builder.Services.AddDbContextServices(builder.Configuration, Constants.CONNECTION_STRING);

builder.Services.AddAuthenticationServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
