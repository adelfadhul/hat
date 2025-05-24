using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ShoppingCartView : ContentPage
{
  
    public ShoppingCartView(ShoppingCartViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }    
}