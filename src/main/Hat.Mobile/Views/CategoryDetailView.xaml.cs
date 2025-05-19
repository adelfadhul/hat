using Hat.DataViewModels;
using Hat.ViewModels;
using MediatR;

namespace Hat.Views;

public partial class CategoryDetailView : ContentPage
{
    public CategoryDetailView(CategoryDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}