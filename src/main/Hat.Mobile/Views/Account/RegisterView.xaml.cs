using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}