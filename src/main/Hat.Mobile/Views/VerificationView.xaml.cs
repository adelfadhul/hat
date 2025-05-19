using Hat.ViewModels;

namespace Hat.Views;

public partial class VerificationView : ContentPage
{
	public VerificationView()
	{
		InitializeComponent();
        BindingContext = new VerificationViewModel();
    }   
}