using Hat.Model;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmPaymentView : ContentPage
{
	public ConfirmPaymentView(ObservableCollection<ProductListModel> products, DeliveryTypeModel deliveryType, AddressModel address)
	{
		InitializeComponent();
        BindingContext = new ConfirmPaymentViewModel(products, deliveryType, address);
    }
}