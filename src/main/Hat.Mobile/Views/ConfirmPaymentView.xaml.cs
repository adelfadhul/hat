using Hat.DataViewModels;
using Hat.ViewModels;

namespace Hat.Views;

public partial class ConfirmPaymentView : ContentPage
{



	public ConfirmPaymentView(AddressViewModel address, ConfirmPaymentViewModel vm)

    {
		InitializeComponent();
        BindingContext = vm;
    }
}