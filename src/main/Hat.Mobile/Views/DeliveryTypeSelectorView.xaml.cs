using Hat.DataViewModels;
using Hat.ViewModels;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class DeliveryTypeSelectorView : ContentPage
{
	
	public DeliveryTypeSelectorView(DeliveryTypeSelectorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}