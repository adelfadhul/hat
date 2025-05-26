using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ShoppingCartView : ContentPage
{
    private readonly ShoppingCartViewModel _viewModel;
    public ShoppingCartView(ShoppingCartViewModel vm)
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