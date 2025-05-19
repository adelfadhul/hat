using Hat.ViewModels;

namespace Hat.Views;

public partial class ShippingAddressView : ContentPage
{
	public ShippingAddressView()
	{
		InitializeComponent();
        BindingContext = new ShippingAddressViewModel();

    }
}