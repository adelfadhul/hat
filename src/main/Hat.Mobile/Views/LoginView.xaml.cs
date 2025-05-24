using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}