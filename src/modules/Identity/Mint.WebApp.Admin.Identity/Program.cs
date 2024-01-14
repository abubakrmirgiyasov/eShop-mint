using Mint.WebApp.Extensions.Identities;
using Mint.WebApp.Extensions;
using Mint.Domain.Common;
using Mint.Infrastructure.Middlewares;
using Mint.WebApp.Admin.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = config.Get<AppSettings>();
builder.Services.Configure<AppSettings>(config);

builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContextServices(builder.Configuration, Constants.CONNECTION_STRING);

builder.Services.AddAuthenticationServices();
builder.Services.AdminServicesCollection();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = appSettings!.IdentitySettings.ValidateIssuer,
            ValidIssuer = appSettings!.IdentitySettings.ValidIssuer,
            ValidateAudience = appSettings!.IdentitySettings.ValidateAudience,
            ValidAudience = appSettings!.IdentitySettings.Audience,
            ValidateLifetime = appSettings!.IdentitySettings.ValidateLifetime,
            IssuerSigningKey = appSettings.IdentitySettings.GetSecurityKey(),
            ValidateIssuerSigningKey = appSettings.IdentitySettings.ValidateIssuerSigningKey,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. " +
                      "\nEnter 'Bearer' [space] and then your token in the text input below. " +
                      "\nExample: Bearer 12345",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
