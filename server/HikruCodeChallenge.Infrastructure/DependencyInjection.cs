using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HikruCodeChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database (InMemory)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("PositionManagementDB"));

            // Repositories
            services.AddScoped<IPositionRepository, PositionRepository>();

            return services;
        }
    }
}
