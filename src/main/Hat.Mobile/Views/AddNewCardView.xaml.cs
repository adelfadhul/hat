using Hat.ViewModels;

namespace Hat.Views;

public partial class AddNewCardView : ContentPage
{
	public AddNewCardView(AddNewCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
   
}