using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ShoppingCartCalculationView : ContentPage
{
	public ShoppingCartCalculationView(ShoppingCartCalculationViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}