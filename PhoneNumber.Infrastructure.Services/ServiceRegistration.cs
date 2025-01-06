
using PhoneNumber.Application.Wrappers;
using PhoneNumber.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SI.Engine.Infrastructure.Services;
using System.Security.Cryptography;
using PhoneNumber.Application.Interfaces;
using PhoneNumber.Infrastructure.Shared.Services;

namespace PhoneNumber.Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void LoadConfigurations(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
        }

        public static void AddServiceInfrastructure(this IServiceCollection services, IConfiguration _config)
        {            
            services.AddTransient<IDapper, DapperService>();
            services.AddTransient<IServiceManager, ServiceManager>();
        }
    }
}