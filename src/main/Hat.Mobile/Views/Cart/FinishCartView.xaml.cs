using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;
public partial class FinishCartView : ContentPage
{
    public FinishCartView(FinishCartViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

    }
}
