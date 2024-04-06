using Bits_Orchestra_Test_Task.Repositories.EmployeeRepository;
using Bits_Orchestra_Test_Task.Services.EmployeeService;

namespace Bits_Orchestra_Test_Task.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        } 
    }
}
