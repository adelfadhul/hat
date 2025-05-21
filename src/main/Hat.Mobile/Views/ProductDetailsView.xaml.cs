using Hat.ViewModels;

namespace Hat.Views;
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