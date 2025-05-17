using Hat.ViewModel;

namespace Hat.Views;

public partial class AddNewCardView : ContentPage
{
	public AddNewCardView()
	{
		InitializeComponent();
		BindingContext = new AddNewCardViewModel();

    }
}