public class NavigationService : INavigationService
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
}
