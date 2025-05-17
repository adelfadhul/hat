using Hat.ViewModel;

namespace Hat.Views;

public partial class CartView : ContentPage
{
    public CartView()
    {
        InitializeComponent();
        BindingContext = new CartViewModel();
    }    
}