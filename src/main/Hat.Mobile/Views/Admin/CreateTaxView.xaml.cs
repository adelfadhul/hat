using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CreateTaxView : ContentPage
{
	public CreateTaxView(CreateVatViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}