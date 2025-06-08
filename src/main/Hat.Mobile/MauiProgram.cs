
using Camera.MAUI;
using CommunityToolkit.Maui;
using Hat.Application.Registeration;
using Hat.DataViewModels;
using Hat.Domain.Identity;
using Hat.Infrastructure.Identity.Memory;
using Hat.Mobile.Services;
using Hat.Mobile.ViewModels;
using Hat.Mobile.Views;
using Hat.ViewModels;



namespace Hat.Mobile;

public static class MauiProgram
{
    
    public static string getBaseUrl()
    {
        var httpPort = 5166;
        var httpsPort = 7068;

#if DEBUG

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            // Check if running on an emulator
            if (DeviceInfo.DeviceType == DeviceType.Virtual)
            {
                // Android Emulator
                return $"http://10.0.2.2:{httpPort}";
            }
            else
            {
                // Physical Android Device - Get local IP of the machine
                //string localIp = GetLocalIPAddress();
                string localIp = "192.168.100.46";
                return $"http://{localIp}:{httpsPort}";
            }
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            // Windows
            return $"http://localhost:{httpsPort}";
        }
        throw new NotSupportedException("Unsupported platform");
#else
            builder.Services.AddWatadClient("https://alwatad.azurewebsites.net");
#endif
    }
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
        builder.Services.AddTransient<CartManagerViewModel>();
        builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<DeliveryTypeViewModel>();
        builder.Services.AddTransient<ShippingAddressSelectorView>();
        builder.Services.AddTransient<CreateCardView>();
        builder.Services.AddTransient<CreateCardViewModel>();
        builder.Services.AddTransient<HomePageViewModel>(); 
        builder.Services.AddTransient<AllProductViewModel>();
        builder.Services.AddTransient<BrandDetailViewModel>();
        builder.Services.AddTransient<CardManagerViewModel>();
        builder.Services.AddTransient<CheckOutViewModel>();
        builder.Services.AddTransient<CategoryDetailViewModel> ();
        builder.Services.AddTransient<ConfirmAddressViewModel>();
        builder.Services.AddTransient<ConfirmPaymentViewModel>();
        builder.Services.AddTransient<ConfirmDeliveryViewModel>();
        builder.Services.AddTransient<FinishCartViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<OrderListViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<OrderTrackViewModel>();
        builder.Services.AddTransient<VerificationViewModel>();
        builder.Services.AddTransient<WishListViewModel>();
        builder.Services.AddTransient<ShippingAddressSelectorViewModel>();
        builder.Services.AddTransient<CreateProductViewModel>();
        builder.Services.AddTransient<CreateVatViewModel>();
        builder.Services.AddTransient<ShippingAddressViewModel>();
        builder.Services.AddTransient<CategoryViewModel>();
        builder.Services.AddTransient<DataService>();
        builder.Services.AddTransient<NavigationService>();
        builder.Services.AddTransient<CreateInventoryViewModel>();

        // Views
        builder.Services.AddTransient<CartManagerView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<HomePageView>();
        builder.Services.AddTransient<RegisterView>();
        builder.Services.AddTransient<ProfileView>();
        builder.Services.AddTransient<AllProductView>();
        builder.Services.AddTransient<BrandDetailView>();
        builder.Services.AddTransient<CardManagerView>();
        builder.Services.AddTransient<CheckOutView>();
        builder.Services.AddTransient<CategoryDetailView>();
        builder.Services.AddTransient<ConfirmAddressView>();
        builder.Services.AddTransient<ConfirmPaymentView>();
        builder.Services.AddTransient<ConfirmDeliveryView>();
        builder.Services.AddTransient<FinishCartView>();
        builder.Services.AddTransient<OrderListView>();
        builder.Services.AddTransient<ProductDetailsView>();
        builder.Services.AddTransient<ShippingAddressSelectorView>();
        builder.Services.AddTransient<OrderTrackView>();
        builder.Services.AddTransient<VerificationView>();
        builder.Services.AddTransient<WishListView>();
        builder.Services.AddTransient<CreateCardView>();
        builder.Services.AddTransient<CreateProductView>();
        builder.Services.AddTransient<CreateVatView>();
        builder.Services.AddTransient<CreateInventoryView>();

        var url = getBaseUrl();
        
        builder.Services.AddHttpClient("Default", client =>
        {
           
            client.BaseAddress = new Uri(url);
        });
        // we use the api client as default HttpClient
       // builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("Default"));


        // Register MediatR handlers from the application assembly
        builder.Services.AddHatApplications("Hat.Application");
        builder.Services.AddScoped<ICurrentUser,MemoryCurrentUser>();


        return builder.Build();
    }
}
