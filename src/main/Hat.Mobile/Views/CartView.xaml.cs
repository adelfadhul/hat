using Hat.ViewModels;
using MediatR;

namespace Hat.Views;

public partial class CartView : ContentPage
{
  
    public CartView(CartViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }    
}