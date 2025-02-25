using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
                        this IServiceCollection services,
                        IConfiguration configuration
    )
        {
            //var mapperConfig = new MapperConfiguration(
            //    mc=> mc.AddProfile(new MappingProfile())
            //    );
            return services;
        }
    }
}
