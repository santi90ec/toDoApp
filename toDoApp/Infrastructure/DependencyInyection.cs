
using Core.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Infrastructure;

namespace Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<toDoContext>(options =>
                            options.UseSqlServer(connectionString));
            return services;
        }
    }
}
