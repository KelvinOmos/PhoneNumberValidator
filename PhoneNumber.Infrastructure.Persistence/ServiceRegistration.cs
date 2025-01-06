using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneNumber.Infrastructure.Contexts;

namespace PhoneNumber.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("PhoneApiDb");
            });
        }
    }
}
