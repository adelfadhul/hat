using Hat.Views;

namespace Hat;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
       
        Routing.RegisterRoute("productdetails", typeof(ProductDetailsView));
        Routing.RegisterRoute("categorydetails", typeof(CategoryDetailView));
        Routing.RegisterRoute("branddetails", typeof(BrandDetailView));
        Routing.RegisterRoute("cart", typeof(CartView));
        Routing.RegisterRoute("allproducts", typeof(AllProductView));
        Routing.RegisterRoute("shippingaddress", typeof(ShippingAddressView));
        Routing.RegisterRoute("addnewcard", typeof(AddNewCardView));
        Routing.RegisterRoute("confirmaddress", typeof(ConfirmAddressView));
        Routing.RegisterRoute("confirmpayment", typeof(ConfirmPaymentView));
        Routing.RegisterRoute("finishcart", typeof(FinishCartView));
        Routing.RegisterRoute("trackorder", typeof(TrackOrderView));
        Routing.RegisterRoute("orderdetails", typeof(OrderDetailsView));
        Routing.RegisterRoute("deliverytypeselector", typeof(DeliveryTypeView));
        Routing.RegisterRoute("wishList", typeof(WishListView));
        Routing.RegisterRoute("allproducts", typeof(AllProductView));
        Routing.RegisterRoute("cartcalculation", typeof(CartCalculationView));
        Routing.RegisterRoute("verification", typeof(VerificationView));
        Routing.RegisterRoute("login", typeof(LoginView));
        Routing.RegisterRoute("register", typeof(RegisterView));
        Routing.RegisterRoute("profile", typeof(ProfileView));
        //Routing.RegisterRoute("camera", typeof(CameraView));
        Routing.RegisterRoute("addnewcard", typeof(AddNewCardView));
        Routing.RegisterRoute("card", typeof(CardView));
        Routing.RegisterRoute("home", typeof(HomePageView));

    }
}
