using ManagerInfoDemo.Repositories;
using ManagerInfoDemo.Repositories.Interface;
using ManagerInfoDemo.Services;
using ManagerInfoDemo.Services.Interfaces;

namespace ManagerInfoDemo.Infrastructure
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            // Register services
            services.AddScoped<IAuthenService, AuthenService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
