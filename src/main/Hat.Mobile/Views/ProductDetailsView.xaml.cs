using Hat.ViewModels;

namespace Hat.Views;

public partial class ProductDetailsView : ContentPage
{
    public ProductDetailsView(ProductDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}