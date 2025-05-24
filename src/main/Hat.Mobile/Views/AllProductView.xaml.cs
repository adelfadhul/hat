
using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;
public partial class AllProductView : ContentPage
{
    public AllProductView(AllProductViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}