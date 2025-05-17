using Hat.Model;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class DeliveryTypeView : ContentPage
{
	public DeliveryTypeView(ObservableCollection<ProductListModel> products)
	{
		InitializeComponent();
        BindingContext = new DeliveryTypeViewModel(products);
    }
}