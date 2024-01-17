using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mint.Domain.Common;
using System.Text;

namespace Mint.WebApp.Extensions.Identities;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = Encoding.ASCII.GetBytes(appSettings.IdentitySettings.SecretKey);
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = appSettings.IdentitySettings.ValidateIssuer,
                    ValidIssuer = appSettings.IdentitySettings.ValidIssuer,
                    ValidateAudience = appSettings.IdentitySettings.ValidateAudience,
                    ValidAudience = appSettings.IdentitySettings.ValidAudience,
                    ValidateIssuerSigningKey = appSettings.IdentitySettings.ValidateIssuerSigningKey,
                    ValidateLifetime = appSettings.IdentitySettings.ValidateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
            });


        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin Identity API", Version = "v1" });

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter JWT Bearer token **ONLY**",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme.ToLower(),
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });
        });

        return services;
    }
}
