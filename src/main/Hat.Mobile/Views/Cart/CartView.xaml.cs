using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CartView : ContentPage
{
    private readonly CartViewModel _viewModel;
    public CartView(CartViewModel vm)
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