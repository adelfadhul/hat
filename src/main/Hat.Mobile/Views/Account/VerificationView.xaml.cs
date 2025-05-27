using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class VerificationView : ContentPage
{
	public VerificationView(VerificationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }   
}