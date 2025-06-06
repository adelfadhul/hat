using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class OrderTrackView : ContentPage
{
    public OrderTrackView(OrderTrackViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}