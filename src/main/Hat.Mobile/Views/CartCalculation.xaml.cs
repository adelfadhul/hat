using Hat.DataViewModels;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class CartCalculation : ContentPage
{
	public CartCalculation(ObservableCollection<ProductListViewModel> ProductList)
	{
		InitializeComponent();
        BindingContext = new CartCalculationViewModel(ProductList);
    }
}