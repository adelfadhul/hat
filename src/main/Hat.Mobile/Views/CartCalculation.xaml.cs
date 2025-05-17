using Hat.Model;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class CartCalculation : ContentPage
{
	public CartCalculation(ObservableCollection<ProductListModel> ProductList)
	{
		InitializeComponent();
        BindingContext = new CartCalculationViewModel(ProductList);
    }
}