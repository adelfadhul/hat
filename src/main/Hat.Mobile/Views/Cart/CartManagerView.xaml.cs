using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CartManagerView : ContentPage
{
    private readonly CartManagerViewModel _viewModel;
    public CartManagerView(CartManagerViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Call the ViewModel's OnNavigatedTo method

        _ = _viewModel.PopulateDataAsync();

    }
}