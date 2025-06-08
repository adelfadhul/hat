using Hat.Domain.Payment;
using Hat.Domain.Store;
using Hat.Infrastructure.Payment.Fake;
using Hat.Infrastructure.Persistance.SqlServer.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Hat.Infrastructure.Registeration
{
    public static class PaymentRegistration
    {
        public static IServiceCollection AddHatPayment(this IServiceCollection services, PaymentType type)
        {
            switch (type)
            {
                case PaymentType.Fake:

                    services.AddSingleton <IPaymentService, FakePaymentService>();

                    break;
                case PaymentType.Tap:
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
