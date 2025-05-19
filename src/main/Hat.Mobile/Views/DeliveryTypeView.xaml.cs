using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Repositories;
using MediatR;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class DeliveryTypeView : ContentPage
{
	
	public DeliveryTypeView(ObservableCollection<ProductListViewModel> products,IMediator mediator)
	{
		InitializeComponent();
        BindingContext = new DeliveryViewModel(products, mediator);
    }
}