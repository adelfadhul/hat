using Hat.ViewModels;
using MediatR;
namespace Hat.Views;

public partial class WishListView : ContentPage
{   
    public WishListView(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new WishListViewModel(mediator);

    }
}