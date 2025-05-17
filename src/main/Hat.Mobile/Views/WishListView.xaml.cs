using Hat.ViewModel;
namespace Hat.Views;

public partial class WishListView : ContentPage
{   
    public WishListView()
	{
		InitializeComponent();
		BindingContext = new WishListViewModel();

    }
}