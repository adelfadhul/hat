using Hat.ViewModels;

namespace Hat.Views;

public partial class CartCalculationView : ContentPage
{
	public CartCalculationView(CartCalculationViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}