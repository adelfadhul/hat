using Hat.Mobile.ViewModels;
namespace Hat.Mobile.Views;

public partial class WishListView : ContentPage
{   
    public WishListView(WishListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}