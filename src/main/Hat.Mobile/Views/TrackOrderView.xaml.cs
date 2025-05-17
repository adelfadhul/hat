using Hat.ViewModel;
using static Hat.Model.TrackOrderModel;

namespace Hat.Views;

public partial class TrackOrderView : ContentPage
{
    public TrackOrderView(Track data)
    {
        InitializeComponent();
        BindingContext = new TrackOrderViewModel(data);
    }
}