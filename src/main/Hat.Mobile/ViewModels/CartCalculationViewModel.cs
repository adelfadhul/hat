using Hat.DataViewModels;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class CartCalculationViewModel : BaseViewModel
    {
        private ObservableCollection<ProductListViewModel> _Products = [];
        public ObservableCollection<ProductListViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        private double _SubTotal = 0;
        public double SubTotal
        {
            get => _SubTotal;
            set => SetProperty(ref _SubTotal, value);
        }
        public ICommand CheckoutCommand { get; }
        public ICommand ApplyVoucherCommand { get; }
        public ICommand BackCommand { get; }

        private readonly IMediator _mediator;
        public CartCalculationViewModel(ObservableCollection<ProductListViewModel> products, IMediator mediator)
        {
            _mediator = mediator;
            Products = products;
            SubTotal = Products.Sum(item => item.Qty * item.Price);
            CheckoutCommand = new Command(Checkout);
            ApplyVoucherCommand = new Command<string>(ApplyVoucher);
            BackCommand = new Command(GoBack);
           
            IsLoaded = true;
        }

        private async void Checkout()
        {
            await MauiApp.Current.MainPage.Navigation.PushAsync(new DeliveryTypeView(Products, _mediator));
        }
        private void ApplyVoucher(string vaucher)
        {

        }

        private async void GoBack(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PopAsync();
        }
    }
}
