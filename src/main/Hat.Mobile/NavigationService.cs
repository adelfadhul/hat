using Hat.Views;

public class NavigationService
{
   

    public NavigationService()
    {
        
    }

    // Navigate to the product details page
  
    public async Task NavigateToProductDetails(Guid productId)
    {
        await Shell.Current.GoToAsync($"{nameof(ProductDetailsView)}?productId={productId}");
    }
    public async Task NavigateToTrackOrder()
    {
        await Shell.Current.GoToAsync($"{nameof(TrackOrderView)}");
    }
    public async Task NavigateToConfirmAddress()
    {
        await Shell.Current.GoToAsync($"{nameof(ConfirmAddressView)}");
    }
    public async Task NavigateToFinishCart()
    {
        await Shell.Current.GoToAsync($"{nameof(FinishCartView)}");
    }
    // Navigate to the home page
    public async Task NavigateToHome()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePageView)}");
    }

    // Navigate to the cart page
    public async Task NavigateToCart()
    {
        await Shell.Current.GoToAsync($"{nameof(CartView)}");
    }



    // Navigate to the login page
    public async Task NavigateToLogin()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
    }

    // Navigate to the registration page
    public async Task NavigateToRegister()
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterView)}");
    }

    // Navigate back
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    // Navigate to the settings page
    public async Task NavigateToSettings()
    {
       // await Shell.Current.GoToAsync($"{nameof(SettingView)}");
    }

    // Navigate to the profile page
    public async Task NavigateToProfile()
    {
        await Shell.Current.GoToAsync($"{nameof(ProfileView)}");
    }

    internal async Task NavigateToAddNewCard()
    {
        await Shell.Current.GoToAsync($"{nameof(AddNewCardView)}");
    }
    // Navigate to the card calculation page
    public async Task NavigateToCartCalculation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartCalculationView)}");
    }
    public async Task NavigateToConfirmPyment()
    {
        await Shell.Current.GoToAsync($"{nameof(ConfirmPaymentView)}");
    }
    public async Task NavigateToDeliveryType()
    {
        await Shell.Current.GoToAsync($"{nameof(DeliveryTypeView)}");
    }
    public async Task NavigateToCategoryDetails()
    {
        await Shell.Current.GoToAsync($"{nameof(CategoryDetailView)}");
    }

    public async Task NavigateToAllProducts()
    {
        await Shell.Current.GoToAsync($"{nameof(AllProductView)}");
    }

    internal async Task NavigateToShippingAddress()
    {
       await Shell.Current.GoToAsync($"{nameof(ShippingAddressSelectorView)}");
    }

    internal async Task NavigateToWhishList()
    {
        await Shell.Current.GoToAsync($"{nameof(WishListView)}");
    }

    internal async Task NavigateToOrderDetails()
    {
        await Shell.Current.GoToAsync($"{nameof(OrderDetailsView)}");
    }

    internal async Task NavigateToCard()
    {
       await Shell.Current.GoToAsync($"{nameof(CardInfoManagerView)}");    
    }
}
