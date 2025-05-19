using Hat.ViewModels;

namespace Hat.Views;

public partial class HomePageView : ContentPage
{

    public HomePageView(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}