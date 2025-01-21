
using Application.Services;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService ,TokenService>();
            services.AddScoped<AuthenticationService>();

            return services;
        }
    }
}
