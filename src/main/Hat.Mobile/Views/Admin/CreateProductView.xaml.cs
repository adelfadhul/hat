using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CreateProductView : ContentPage
{
	public CreateProductView(CreateProductViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}