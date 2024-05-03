using Microsoft.Extensions.DependencyInjection;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Identity.Application.Operations.Repositories;
using Mint.Infrastructure.Repositories.Identity;
using Mint.Application.Interfaces;
using Mint.Infrastructure.Services;
using Mint.Domain.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Mint.WebApp.Client.Application.Operations.Services;
using Mint.Infrastructure.Services.Client;
using Mint.WebApp.Client.Application.Operations.Repositories;
using Mint.Infrastructure.Repositories.Client;
using Mint.Application.Repositories;
using Mint.Infrastructure.Repositories.Common;

namespace Mint.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // services
        services.AddScoped<IRedisCacheService, RedisCacheService>();
        services.AddScoped<IStorageCloudService, StorageCloudService>();

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    public static IServiceCollection AddAdminServices(this IServiceCollection services)
    {
        //services.AddScoped<ITagService, TagService>();

        return services;
    }

    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<IClientCategoryService, ClientCategoryService>();

        return services;
    }

    public static IServiceCollection AddAdminRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IManufactureRepository, ManufactureRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();

        return services;
    }

    public static IServiceCollection AddClientRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClientCategoryRepository, ClientCategoryRepository>();

        return services;
    }

    public static IServiceCollection AddAdminIdentityRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAdminAuthenticationRepository, AdminAuthenticationRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();

        return services;
    }

    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
    {
        // services
        services.AddScoped<IJwtService, JwtService>();

        // repositories
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddCommonRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();

        return services;
    }

    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, AppSettings? appSettings)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = Encoding.ASCII.GetBytes(appSettings!.IdentitySettings.SecretKey);
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
            options.SwaggerDoc("v1", new OpenApiInfo { Title = appSettings?.AppVersion.SwaggerTitle, Version = "v1" });

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
