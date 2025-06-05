using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CreateCardView : ContentPage
{
	public CreateCardView(CreateCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
   
}