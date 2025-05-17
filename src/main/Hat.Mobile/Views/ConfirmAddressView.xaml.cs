using Hat.Model;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmAddressView : ContentPage
{
	public ConfirmAddressView(ObservableCollection<ProductListModel> products, DeliveryTypeModel deliveryType)
	{
		InitializeComponent();
        BindingContext = new ConfirmAddressViewModel(products, deliveryType);
    }
}