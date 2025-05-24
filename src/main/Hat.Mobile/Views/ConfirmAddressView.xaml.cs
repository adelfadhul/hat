using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ConfirmAddressView : ContentPage
{


	public ConfirmAddressView(ConfirmAddressViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}