using Hat.Model;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class FinishCartView : ContentPage
{
	public FinishCartView(ObservableCollection<ProductListModel> products, DeliveryTypeModel deliveryType, AddressModel address, CardInfoModel card)
	{
		InitializeComponent();
		BindingContext = new FinishCartViewModel(products, deliveryType, address, card);

    }
}