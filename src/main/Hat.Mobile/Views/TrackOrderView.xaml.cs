using Hat.ViewModels;

namespace Hat.Views;

public partial class TrackOrderView : ContentPage
{
    public TrackOrderView(TrackOrderViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}