using Hat.ViewModel;

namespace Hat.Views;

public partial class CardView : ContentPage
{
    public CardView()
	{
		InitializeComponent();
		BindingContext = new CardViewModel();

    }
}