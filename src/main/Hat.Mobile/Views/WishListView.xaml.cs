using Hat.ViewModels;
using MediatR;
namespace Hat.Views;

public partial class WishListView : ContentPage
{   
    public WishListView(WishListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}