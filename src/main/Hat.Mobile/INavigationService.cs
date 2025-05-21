public interface INavigationService
{
    Task PushModalAsync<TView>() where TView : Page;
}
