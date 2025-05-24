using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class CategoryDetailView : ContentPage
{
    public CategoryDetailView(CategoryDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}