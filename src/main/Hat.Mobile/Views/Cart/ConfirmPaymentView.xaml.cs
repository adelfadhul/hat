using Hat.DataViewModels;
using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ConfirmPaymentView : ContentPage
{



	public ConfirmPaymentView(ShippingAddressViewModel address, ConfirmPaymentViewModel vm)

    {
		InitializeComponent();
        BindingContext = vm;
    }
}