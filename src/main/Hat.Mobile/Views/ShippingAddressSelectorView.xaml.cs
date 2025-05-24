using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ShippingAddressSelectorView : ContentPage
{
	public ShippingAddressSelectorView(ShippingAddressSelectorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}