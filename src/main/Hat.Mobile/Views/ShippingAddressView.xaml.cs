using Hat.ViewModel;

namespace Hat.Views;

public partial class ShippingAddressView : ContentPage
{
	public ShippingAddressView()
	{
		InitializeComponent();
        BindingContext = new ShippingAddressViewModel();

    }
}