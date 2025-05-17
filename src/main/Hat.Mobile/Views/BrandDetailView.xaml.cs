using Hat.ViewModel;

namespace Hat.Views;

public partial class BrandDetailView : ContentPage
{
    public BrandDetailView()
    {
        InitializeComponent();
        BindingContext = new BrandDetailViewModel();
    }
}