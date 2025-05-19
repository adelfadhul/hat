using Hat.DataViewModels;
using Hat.ViewModels;
using MediatR;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class CartCalculation : ContentPage
{
	public CartCalculation(CartCalculationViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}