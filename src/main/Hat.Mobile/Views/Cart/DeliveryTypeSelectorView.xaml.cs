using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class DeliveryTypeSelectorView : ContentPage
{
	
	public DeliveryTypeSelectorView(DeliveryTypeSelectorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}