using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.ViewModels;
using System.Collections.ObjectModel;

namespace Hat.Views;
public partial class FinishCartView : ContentPage
{
    public FinishCartView(ObservableCollection<ProductViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
    {
        InitializeComponent();
        BindingContext = new FinishCartViewModel(products, deliveryType, address, card);

    }
}
