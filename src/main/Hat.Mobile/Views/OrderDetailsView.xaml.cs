using Hat.ViewModels;

namespace Hat.Views;

public partial class OrderDetailsView : ContentPage
{
    public OrderDetailsView(OrderDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}