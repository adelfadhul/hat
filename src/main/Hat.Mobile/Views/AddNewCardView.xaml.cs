using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class AddNewCardView : ContentPage
{
	public AddNewCardView(AddNewCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
   
}