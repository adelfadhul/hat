using Hat.ViewModels;

namespace Hat.Views;

public partial class CardView : ContentPage
{
    public CardView(CardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}