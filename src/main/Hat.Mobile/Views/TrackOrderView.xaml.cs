using Hat.ViewModels;

namespace Hat.Views;

public partial class TrackOrderView : ContentPage
{
    public TrackOrderView(TrackViewModel data)
    {
        InitializeComponent();
        BindingContext = new TrackOrderViewModel(data);
    }
}