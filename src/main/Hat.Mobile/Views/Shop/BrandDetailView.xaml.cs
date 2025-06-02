using Hat.ViewModels;

namespace Hat.Mobile.Views;

public partial class BrandDetailView : ContentPage
{
    
    public BrandDetailView(BrandDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext =vm;
    }
}