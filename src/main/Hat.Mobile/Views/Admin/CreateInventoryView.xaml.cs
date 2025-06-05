using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CreateInventoryView : ContentPage
{
	public CreateInventoryView(CreateInventoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}