using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneNumber.Application.Interfaces;
using PhoneNumber.Infrastructure.Persistence.Contexts;

namespace PhoneNumber.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("PhoneApiDb");
            });
        }
    }
}
