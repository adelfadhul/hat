using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CardInfoManagerView : ContentPage
{
    public CardInfoManagerView(CardInfoManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}