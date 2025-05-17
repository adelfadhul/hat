using Hat.DataViewModels;
using Hat.ViewModel;
using System.Collections.ObjectModel;

namespace Hat.Views;

public partial class FinishCartView : ContentPage
{

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public FinishCartView(ObservableCollection<ProductListViewModel> products, Model.DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
	{
=======
	public FinishCartView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
	{
>>>>>>> After

<<<<<<< TODO: Unmerged change from project 'Hat.Mobile (net8.0-android)', Before:
	public FinishCartView(ObservableCollection<ProductListViewModel> products, ViewModelObjects.DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
	{
=======
	public FinishCartView(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
	{
>>>>>>> After
	public FinishCartView(ObservableCollection<ProductListViewModel> products, DataViewModels.DeliveryTypeDataViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
	{
		InitializeComponent();
		BindingContext = new FinishCartViewModel(products, deliveryType, address, card);

    }
}