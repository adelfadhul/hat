public class NavigationService 
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PushModalAsync<TView>() where TView : Page
    {
        var page = _serviceProvider.GetRequiredService<TView>();
        await Application.Current.MainPage.Navigation.PushModalAsync(page);
    }
    public async Task NavigateToProductDetails(Guid productId)
    {
        await Shell.Current.GoToAsync($"productdetails?productId={productId.ToString()}");
    }
}
