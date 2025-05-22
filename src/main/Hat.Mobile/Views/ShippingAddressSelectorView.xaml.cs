using Hat.ViewModels;

namespace Hat.Views;

public partial class ShippingAddressSelectorView : ContentPage
{
	public ShippingAddressSelectorView(ShippingAddressSelectorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}