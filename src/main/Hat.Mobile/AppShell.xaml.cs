using Hat.Mobile.ViewModels;
using Hat.Mobile.Views;
using System.Threading.Tasks;


namespace Hat.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DeliveryTypeSelectorView), typeof(DeliveryTypeSelectorView));
        Routing.RegisterRoute(nameof(ProductDetailsView), typeof(ProductDetailsView));
        Routing.RegisterRoute(nameof(CategoryDetailView), typeof(CategoryDetailView));
        Routing.RegisterRoute(nameof(BrandDetailView), typeof(BrandDetailView));
        Routing.RegisterRoute(nameof(ShoppingCartView), typeof(ShoppingCartView));
        Routing.RegisterRoute(nameof(ShippingAddressSelectorView), typeof(ShippingAddressSelectorView));
        Routing.RegisterRoute(nameof(CreateCardView), typeof(CreateCardView));
        Routing.RegisterRoute(nameof(ConfirmAddressView), typeof(ConfirmAddressView));
        // Register route for confirm payment navigation
        Routing.RegisterRoute(nameof(ConfirmPaymentView), typeof(ConfirmPaymentView));
        Routing.RegisterRoute(nameof(FinishCartView), typeof(FinishCartView));
        Routing.RegisterRoute(nameof(TrackOrderView), typeof(TrackOrderView));
        Routing.RegisterRoute(nameof(OrderDetailsView), typeof(OrderDetailsView));
        Routing.RegisterRoute(nameof(WishListView), typeof(WishListView));
        Routing.RegisterRoute(nameof(AllProductView), typeof(AllProductView));
        Routing.RegisterRoute(nameof(CheckOutView), typeof(CheckOutView));
        Routing.RegisterRoute(nameof(VerificationView), typeof(VerificationView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
        Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
        //Routing.RegisterRoute(nameof(CameraView), typeof(CameraView));
        Routing.RegisterRoute(nameof(CreateCardView), typeof(CreateCardView));
        Routing.RegisterRoute(nameof(CardManagerView), typeof(CardManagerView));
        Routing.RegisterRoute(nameof(HomePageView), typeof(HomePageView));
        Routing.RegisterRoute(nameof(CreateProductView), typeof(CreateProductView));
        Routing.RegisterRoute(nameof(CreateVatView), typeof(CreateVatView));
        Routing.RegisterRoute(nameof(CreateInventoryView), typeof(CreateInventoryView));
    }

   


}
