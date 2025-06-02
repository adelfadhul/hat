using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CreateVatView : ContentPage
{
	public CreateVatView(CreateVatViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}