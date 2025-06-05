using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CardManagerView : ContentPage
{
    public CardManagerView(CardManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}