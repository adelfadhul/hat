
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.ViewModels;
using MediatR;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmAddressView : ContentPage
{


	public ConfirmAddressView(ConfirmAddressViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}