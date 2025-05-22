using Hat.ViewModels;

namespace Hat.Views;

public partial class CardInfoManagerView : ContentPage
{
    public CardInfoManagerView(CardInfoManagerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}