using BillReminder.Api.Authorization;
using BillReminder.Api.Filters;
using BillReminder.Api.Options;
using BillReminder.Application.Validation;
using BillReminder.Domain.DTO;
using BillReminder.Infra.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scrutor;
using System.Text.Json.Serialization;

namespace BillReminder.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BillReminderContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection AddInfrastructureAndServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
                .Scan(selector => selector
                                    .FromAssemblies(
                                            Infra.AssemblyReference.Assembly,
                                            Application.AssemblyReference.Assembly)
                                    .AddClasses(false)
                                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                                    .AsMatchingInterface()
                .WithScopedLifetime());

        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName))
                .AddOptions()
                .BuildServiceProvider();

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CategoryRequestValidation>();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services
            .AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidationAttribute));
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddHttpContextAccessor();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillReminder", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
                });
        });

        services.AddStackExchangeRedisCache(o => {
            o.InstanceName = "instance";
            o.Configuration = "localhost:6379";
        });

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddAuthorization();
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }
}
