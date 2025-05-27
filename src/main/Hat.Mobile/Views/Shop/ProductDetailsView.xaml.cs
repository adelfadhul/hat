using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;
[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductDetailsView : ContentPage
{
    public string ProductId { get; set; }
    public ProductDetailsView(ProductDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}