using FitFriends.API.Middlewares;
using FitFriends.Application.Interfaces;
using FitFriends.Application.Services;
using FitFriends.Infrastructure;
using FitFriends.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FitFriends.API.AppExtensions
{
    public static class ApiExtension
    {
        public static IServiceCollection AddDomains(this IServiceCollection services) 
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlingMiddleware>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderStore, OrderRepository>();
            services.AddScoped<IUserStore, UserRepository>();

            return services;
        }

        public static IServiceCollection AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions? jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    options.Events = new()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["is-not-token"];

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
