using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class HomePageView : ContentPage
{

    public HomePageView(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}