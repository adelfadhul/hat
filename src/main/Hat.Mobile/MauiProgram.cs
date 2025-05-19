
using Camera.MAUI;
using CommunityToolkit.Maui;
using Hat.Application.Registeration;
using Hat.Infrastructure.Registeration;
using Hat.ViewModels;
using Hat.Views;
using Microsoft.Extensions.Http;


namespace Hat;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCameraView()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Material-Icon.ttf", "MaterialIcon");
                fonts.AddFont("FontAwesome6-Brands.otf", "FA6Brands");
                fonts.AddFont("FontAwesome6-Regular.otf", "FA6Regular");
            });

        // ViewModels
        builder.Services.AddTransient<HomePageViewModel>(); 
        builder.Services.AddTransient<AllProductViewModel>();
        builder.Services.AddTransient<BrandDetailViewModel>();
        builder.Services.AddTransient<CardViewModel>();
        builder.Services.AddTransient<CartCalculationViewModel>();
        builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<CategoryDetailViewModel> ();
        builder.Services.AddTransient<ConfirmAddressViewModel>();
        builder.Services.AddTransient<ConfirmPaymentViewModel>();
        builder.Services.AddTransient<DeliveryTypeSelectorViewModel>();
        builder.Services.AddTransient<FinishCartViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<OrderDetailsViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<TrackOrderViewModel>();
        builder.Services.AddTransient<VerificationViewModel>();
        builder.Services.AddTransient<WishListViewModel>();

        // Views
        builder.Services.AddTransient<HomePageView>();
        builder.Services.AddTransient<AllProductView>();
        builder.Services.AddTransient<BrandDetailView>();
        builder.Services.AddTransient<CardView>();
        builder.Services.AddTransient<CartCalculationView>();
        builder.Services.AddTransient<CartView>();
        builder.Services.AddTransient<CategoryDetailView>();
        builder.Services.AddTransient<ConfirmAddressView>();
        builder.Services.AddTransient<ConfirmPaymentView>();
        builder.Services.AddTransient<DeliveryTypeView>();
        builder.Services.AddTransient<FinishCartView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<OrderDetailsView>();
        builder.Services.AddTransient<ProductDetailsView>();
        builder.Services.AddTransient<ShippingAddressView>();
        builder.Services.AddTransient<TrackOrderView>();
        builder.Services.AddTransient<VerificationView>();
        builder.Services.AddTransient<WishListView>();
        builder.Services.AddTransient<AddNewCardView>();

        builder.Services.AddHttpClient("Default", client =>
        {
            client.BaseAddress = new Uri("localhost:7068");
        });


        // Register MediatR handlers from the application assembly
        builder.Services.AddHatApplications("Hat.Application");

      

        return builder.Build();
    }
}
