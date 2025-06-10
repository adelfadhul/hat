using Hat.Domain.Identity;
using Hat.Infrastructure.Identity.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hat.Infrastructure.Registeration
{
    public static class IdentityRegistration
    {
        public static IServiceCollection AddHatIdentity(this IServiceCollection services, IdentityType type)
        {
            switch (type)
            {
                case  IdentityType.Memory:

                    //services.AddSingleton<ILoginService, MemoryLoginService>();
                    services.AddSingleton<IUserContext, HeaderUserContext>();
                    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    break;
                case IdentityType.AzureB2C:
                    
                    break;
               
                default:
                    throw new ArgumentException($"Unknown repository type: {type}");
            }

            return services;
        }
    }
}
