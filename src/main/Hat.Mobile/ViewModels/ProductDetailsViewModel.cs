using Hat.DataViewModels;
using Hat.Domain.Models;
using System.Net.Http.Json;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    [QueryProperty(nameof(ProductId), "productId")]
    public class ProductDetailsViewModel : BaseViewModel
    {
        double lastScrollIndex;
        double currentScrollIndex;       

        private bool _IsFooterVisible = false;
        public bool IsFooterVisible
        {
            get => _IsFooterVisible;
            set => SetProperty(ref _IsFooterVisible, value);
        }

        private bool _IsFavorite = false;
        public bool IsFavorite
        {
            get => _IsFavorite;
            set
            {
                if ( _IsFavorite != value)
                {
                    _IsFavorite = value;
                    OnPropertyChanged(nameof(IsFavorite));
                    OnPropertyChanged(nameof(FavStatusColor));
                }
            }
        }
        public Color FavStatusColor
        {
            get
            {
                if (IsFavorite)
                {
                    return Color.FromArgb("#00C569");
                }
                return Color.FromArgb("#000000");
            }
        }

        private ProductViewModel _ProductDetail = new();
        public ProductViewModel ProductDetail
        {
            get => _ProductDetail;
            set => SetProperty(ref _ProductDetail, value);
        }

        private bool _IsLoaded;

      
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand FavCommand { get; }
        public ICommand AddToCartCommand { get; }
        private string productId;
        public string ProductId
        {
            get => productId;
            set
            {
                productId = value;
                // Trigger loading logic
               _= PopulateDataAsync(productId);//fire and forget
            }
        }

        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public ProductDetailsViewModel(IHttpClientFactory httpClientFactory, NavigationService navigationService)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
            BackCommand = new Command<object>(GoBack);
            FavCommand = new Command<Color>(FavItem);
            AddToCartCommand = new Command(AddToCart);
            _ = InitializeAsync();
            _navigationService = navigationService;
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync(ProductId);
        }

        async Task PopulateDataAsync(string productId)
        {
            if(string.IsNullOrEmpty(productId))
            {
                return;
            }
            var storedProduct= await _httpClient.GetFromJsonAsync<ProductModel>($"/api/products/{productId}");
            ProductDetail = new ProductViewModel(storedProduct);
            IsLoaded = true;
        }
        private async void GoBack(object obj)
        {
           await _navigationService.GoBack();
        }

        private void FavItem(Color obj)
        {
            IsFavorite = true ? !IsFavorite : IsFavorite;
        }
        public void ChageFooterVisibility(double currentY)
        {
            currentScrollIndex = currentY;
            if (currentScrollIndex > lastScrollIndex)
            {
                IsFooterVisible = false;
            }
            else
            {
                IsFooterVisible = true;
            }
            lastScrollIndex = currentScrollIndex;
        }

        private void AddToCart()
        {
           
        }       
    }
}
