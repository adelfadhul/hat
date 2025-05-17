using Hat.ViewModel;

namespace Hat.Views;

public partial class VerificationView : ContentPage
{
	public VerificationView()
	{
		InitializeComponent();
        BindingContext = new VerificationViewModel();
    }   
}