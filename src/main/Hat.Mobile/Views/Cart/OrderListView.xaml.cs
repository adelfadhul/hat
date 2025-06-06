using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class OrderListView : ContentPage
{
    public OrderListView(OrderListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}