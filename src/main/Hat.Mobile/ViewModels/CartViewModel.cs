using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
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

        public ICommand DeleteCommand { get; }
        public ICommand FavoriteCommand { get; }
        public ICommand QtyChangeCommand { get; }
        public ICommand CheckoutCommand { get; }



        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public CartViewModel(NavigationService navigationService, DeliveryTypeViewModel deliveryTypeViewModel,CartCalculationViewModel cartCalculationViewModel, IHttpClientFactory httpClientFactory)
        {
          
            _navigationService = navigationService;
            _httpClient = httpClientFactory.CreateClient("Default");
            DeleteCommand = new Command<ProductViewModel>(DeleteProduct);
            FavoriteCommand = new Command<ProductViewModel>(FavoriteProduct);
            QtyChangeCommand = new Command<ProductViewModel>(ChangeProductQty);
            CheckoutCommand = new Command(Checkout);
            _ = InitializeAsync();
        }      

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {

            var storedProducts = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/products");
            Products = storedProducts.Select(x=> new ProductViewModel(x)).ToObservableCollection();
            SubTotal = Products.Sum(item => item.Qty * item.Price);
            IsLoaded = true;
        }
        private async void DeleteProduct(ProductViewModel product)
        {
            
        }
        private async void FavoriteProduct(ProductViewModel product)
        {

        }
        private void ChangeProductQty(ProductViewModel product)
        {
            SubTotal = Products.Sum(item => item.Qty * item.Price);
        }
        private async void Checkout()
        {
            await _navigationService.NavigateToCartCalculation();
           // await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(new CartCalculationView(_cartCalculationViewModel));
        }
    }
}
