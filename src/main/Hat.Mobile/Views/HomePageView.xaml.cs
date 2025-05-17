using Hat.ViewModel;

namespace Hat.Views;

public partial class HomePageView : ContentPage
{
    public HomePageView()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel();
    }

}