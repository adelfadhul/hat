using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CheckOutView : ContentPage
{
	public CheckOutView(CheckOutViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}