using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ConfirmDeliveryView : ContentPage
{
	
	public ConfirmDeliveryView(ConfirmDeliveryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}