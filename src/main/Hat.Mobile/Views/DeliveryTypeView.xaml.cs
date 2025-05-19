using Hat.DataViewModels;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class DeliveryTypeView : ContentPage
{
	
	public DeliveryTypeView(ObservableCollection<ProductViewModel> products, DeliveryTypeViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}