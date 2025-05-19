using Hat.ViewModels;
using MediatR;

namespace Hat.Views;

public partial class BrandDetailView : ContentPage
{
    
    public BrandDetailView(BrandDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext =vm;
    }
}