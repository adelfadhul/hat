using Hat.DataViewModels;
using Hat.ViewModel;

namespace Hat.Views;

public partial class CategoryDetailView : ContentPage
{
    public CategoryDetailView(CategoryViewModel data)
    {
        InitializeComponent();
        BindingContext = new CategoryDetailViewModel(data);
    }
}