using Hat.Domain.Identity;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;
using Hat.Infrastructure.Persistance.Memory.Features;
using Hat.Infrastructure.Persistance.SqlServer.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Hat.Infrastructure.Registeration
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddHatRepositories(this IServiceCollection services, string type)
        {
            switch (type)
            {
                case "Memory":
                    services.AddScoped<IShoppingCartRepository, MemoryShoppingCartRepository>();
                    services.AddScoped<IProductRepository, MemoryProductRepository>();
                    services.AddScoped<ICardRepository, MemoryCardRepository>();
                    services.AddScoped<IDeliveryTypeRepository, MemoryDeliveryTypeRepository>();
                    services.AddScoped<ITrackRepository, MemoryTrackRepository>();
                    services.AddScoped<ICategoryRepository, MemoryCategoryRepository>();
                    services.AddScoped<IDeliveryStepRepository, MemoryDeliveryStepRepository>();
                    services.AddScoped<IShippingAddressRepository, MemoryShippingAddressRepository>();
                    services.AddScoped<IReviewRepository, MemoryReviewRepository>();
                    services.AddScoped<ICurrentUser, MemoryCurrentUser>();
                    break;
                case "SqlServer":
                    services.AddScoped<IProductRepository, SqlServerProductRepository>();
                    // Add other SqlServer repositories here as needed
                    break;
               
                default:
                    throw new ArgumentException($"Unknown repository type: {type}");
            }

            return services;
        }
    }
}
