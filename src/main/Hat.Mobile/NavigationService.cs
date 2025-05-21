public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // Navigate to the product details page
    public async Task NavigateToProductDetails(Guid productId)
    {
        await Shell.Current.GoToAsync($"productdetails?productId={productId}");
    }

    // Navigate to the home page
    public async Task NavigateToHome()
    {
        await Shell.Current.GoToAsync("//home");
    }

    // Navigate to the cart page
    public async Task NavigateToCart()
    {
        await Shell.Current.GoToAsync("cart");
    }

    // Navigate to the login page
    public async Task NavigateToLogin()
    {
        await Shell.Current.GoToAsync("//login");
    }

    // Navigate to the registration page
    public async Task NavigateToRegister()
    {
        await Shell.Current.GoToAsync("register");
    }

    // Navigate back
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    // Navigate to the settings page
    public async Task NavigateToSettings()
    {
        await Shell.Current.GoToAsync("settings");
    }

    // Navigate to the profile page
    public async Task NavigateToProfile()
    {
        await Shell.Current.GoToAsync("profile");
    }

    internal async Task NavigateToAddNewCard()
    {
        await Shell.Current.GoToAsync("addnewcard");
    }
}
