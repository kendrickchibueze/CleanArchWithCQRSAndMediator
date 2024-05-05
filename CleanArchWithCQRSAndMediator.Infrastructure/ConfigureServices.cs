using CleanArchWithCQRSAndMediator.Domain.Repository;
using CleanArchWithCQRSAndMediator.Infrastructure.Data;
using CleanArchWithCQRSAndMediator.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRSAndMediator.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConn") ?? 
                    throw new InvalidOperationException("Connection String not found ")));

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }

}

