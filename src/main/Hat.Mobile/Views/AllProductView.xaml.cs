using Hat.ViewModel;
namespace Hat.Views;
public partial class AllProductView : ContentPage
{
    public AllProductView()
    {
        InitializeComponent();
        BindingContext = new AllProductViewModel();
    }
}