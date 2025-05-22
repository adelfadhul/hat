using Hat.DataViewModels;
using Hat.ViewModels;

namespace Hat.Views;

public partial class ConfirmPaymentView : ContentPage
{



	public ConfirmPaymentView(DataViewModels.ShippingAddressViewModel address, ConfirmPaymentViewModel vm)

    {
		InitializeComponent();
        BindingContext = vm;
    }
}