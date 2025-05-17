using Hat.ViewModel;

namespace Hat.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView()
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
}