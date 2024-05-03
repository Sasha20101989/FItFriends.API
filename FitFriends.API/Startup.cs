using FitFriends.API.AppExtensions;
using FitFriends.API.Middlewares;
using FitFriends.Application.Interfaces.Auth;
using FitFriends.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;

namespace FitFriends.API
{
    public class Startup(IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddLogging();
            services.AddExceptionHandler();

            services.AddApiAuthentication(configuration);

            services.AddDomains();
            services.AddRepositories();

            services.AddScoped<IJwtProvider, JwtProvider>();    
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCookiePolicy(new()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
