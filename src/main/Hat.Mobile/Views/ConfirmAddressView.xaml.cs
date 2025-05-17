using Hat.DataViewModels;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmAddressView : ContentPage
{

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public ConfirmAddressView(ObservableCollection<ProductListViewModel> products, Model.DeliveryTypeViewModel deliveryType)
	{
=======
	public ConfirmAddressView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType)
	{
>>>>>>> After

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public ConfirmAddressView(ObservableCollection<ProductListViewModel> products, ViewModelObjects.DeliveryTypeViewModel deliveryType)
	{
=======
	public ConfirmAddressView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType)
	{
>>>>>>> After
	public ConfirmAddressView(ObservableCollection<ProductListViewModel> products, DataViewModels.DeliveryTypeViewModel deliveryType)
	{
		InitializeComponent();
        BindingContext = new ConfirmAddressViewModel(products, deliveryType);
    }
}