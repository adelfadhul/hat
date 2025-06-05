using Hat.DataViewModels;
using Hat.Mobile.ViewModels;
using System.Collections.ObjectModel;

namespace Hat.Mobile.Views;
public partial class FinishCartView : ContentPage
{
    public FinishCartView(ObservableCollection<ProductViewModel> products, DeliveryTypeViewModel deliveryType, ShippingAddressViewModel address, CardViewModel card)
    {
        InitializeComponent();
        BindingContext = new FinishCartViewModel(products, deliveryType, address, card);

    }
}
