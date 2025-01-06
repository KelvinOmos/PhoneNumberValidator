using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace PhoneNumber.Extensions
{
    public static class ServiceExtensions
    {
      
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            
            services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(string.Format(@"{0}\SI.Engine.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Phone Number Validation",
                    Description = "This Api will be responsible for overall phone number validation",
                    Contact = new OpenApiContact
                    {
                       
                    }
                });
            });
        }
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }
    }
}
