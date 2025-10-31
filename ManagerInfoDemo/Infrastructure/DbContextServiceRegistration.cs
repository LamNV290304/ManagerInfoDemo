using Microsoft.EntityFrameworkCore;
using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.Infrastructure
{
    public static class DbContextServiceRegistration
    {
        public static IServiceCollection AddDbContextLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
