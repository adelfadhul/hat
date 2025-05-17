using Hat.Model;
using Hat.ViewModel;

namespace Hat.Views;

public partial class CategoryDetailView : ContentPage
{
    public CategoryDetailView(CategoriesModel data)
    {
        InitializeComponent();
        BindingContext = new CategoryDetailViewModel(data);
    }
}