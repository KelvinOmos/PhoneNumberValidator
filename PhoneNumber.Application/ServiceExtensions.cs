using Microsoft.Extensions.DependencyInjection;

namespace PhoneNumber.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ApplicationException>();
        }
    }
}