using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.WebApp.Identity.Repositories;
using Mint.WebApp.Identity.Repositories.Interfaces;
using Mint.WebApp.Identity.Services;
using Mint.WebApp.Identity.Services.Interfaces;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((cors) => cors.AddPolicy(MyAllowSpecificOrigins, policy =>
{
    policy.WithOrigins("http://127.0.0.1:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
}));

var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);

var connection = builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

//app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
