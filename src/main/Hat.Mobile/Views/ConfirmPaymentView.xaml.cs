using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Repositories;
using Hat.ViewModels;
using MediatR;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmPaymentView : ContentPage
{



	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, DeliveryTypeModel deliveryType, AddressViewModel address, IMediator mediator)
	{
		InitializeComponent();
        BindingContext = new ConfirmPaymentViewModel(products, deliveryType, address, mediator);
    }
}