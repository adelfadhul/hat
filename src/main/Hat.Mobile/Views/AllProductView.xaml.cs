using Hat.ViewModels;
namespace Hat.Views;
public partial class AllProductView : ContentPage
{
    public AllProductView(AllProductViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}