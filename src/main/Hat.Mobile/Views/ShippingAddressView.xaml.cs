using Hat.ViewModels;

namespace Hat.Views;

public partial class ShippingAddressView : ContentPage
{
	public ShippingAddressView(ShippingAddressViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}