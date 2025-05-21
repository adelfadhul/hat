using Hat.ViewModels;

namespace Hat.Views;

public partial class VerificationView : ContentPage
{
	public VerificationView(VerificationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }   
}