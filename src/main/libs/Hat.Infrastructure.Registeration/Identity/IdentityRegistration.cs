using Hat.Domain.Identity;
using Hat.Infrastructure.Identity.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Hat.Infrastructure.Registeration
{
    public static class IdentityRegistration
    {
        public static IServiceCollection AddHatIdentity(this IServiceCollection services, IdentityType type)
        {
            switch (type)
            {
                case  IdentityType.Memory:

                    services.AddSingleton<ILoginService, MemoryLoginService>();
                   
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
