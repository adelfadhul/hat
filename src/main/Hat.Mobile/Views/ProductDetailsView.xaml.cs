using Hat.ViewModels;

namespace Hat.Views;

public partial class ProductDetailsView : ContentPage
{
    public ProductDetailsView()
    {
        InitializeComponent();
        BindingContext = new ProductDetailsViewModel();
    }

}