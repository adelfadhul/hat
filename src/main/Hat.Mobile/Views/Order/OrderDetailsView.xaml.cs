using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class OrderDetailsView : ContentPage
{
    public OrderDetailsView(OrderDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}