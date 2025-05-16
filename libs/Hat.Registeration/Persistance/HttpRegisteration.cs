using Hat.Domain.Repositories;
using Hat.Infrastructure.Persistance.Http.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Hat.Infrastructure.Registeration.Persistance
{
    public static class HttpRegisteration
    {
        public static IServiceCollection AddWatadHttp(this IServiceCollection services, string baseUrl)
        {
            services.AddHttpClient<IProductRepository, HttpProductRepository>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
            //  services.AddTransient<IRoomRepository, HttpRoomRepository>();
            return services;
        }
    }
}
