using Hat.DataViewModels;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class DeliveryTypeView : ContentPage
{
	public DeliveryTypeView(ObservableCollection<ProductListViewModel> products)
	{
		InitializeComponent();
        BindingContext = new DeliveryTypeViewModel(products);
    }
}