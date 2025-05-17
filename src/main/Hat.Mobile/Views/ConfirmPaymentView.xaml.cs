using Hat.DataViewModels;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class ConfirmPaymentView : ContentPage
{

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, Model.DeliveryTypeViewModel deliveryType, AddressViewModel address)
	{
=======
	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address)
	{
>>>>>>> After

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, ViewModelObjects.DeliveryTypeViewModel deliveryType, AddressViewModel address)
	{
=======
	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address)
	{
>>>>>>> After
	public ConfirmPaymentView(ObservableCollection<ProductListViewModel> products, DataViewModels.DeliveryTypeDataViewModel deliveryType, AddressViewModel address)
	{
		InitializeComponent();
        BindingContext = new ConfirmPaymentViewModel(products, deliveryType, address);
    }
}