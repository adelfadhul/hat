using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class TrackOrderView : ContentPage
{
    public TrackOrderView(TrackOrderViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}