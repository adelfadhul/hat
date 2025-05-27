using Hat.DataViewModels;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
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

        private double qty => ProductDetail?.Qty ?? 1;
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

       public ProductDetailsViewModel(NavigationService navigationService,DataService dataService):base(navigationService,dataService)
        {
           
            BackCommand = new Command<object>(GoBack);
            FavCommand = new Command<Color>(FavItem);
            // Update the AddToCartCommand initialization to match the expected Action<object> signature
            AddToCartCommand = new Command<object>(async (obj) => await AddToCart());
            _ = InitializeAsync();
    
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync(productId);
        }

        async Task PopulateDataAsync(string productId)
        {
            if(string.IsNullOrEmpty(productId))
            {
                return;
            }
            var storedProduct = await _dataService.GetProductById(Guid.Parse(productId));
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

        private async Task AddToCart()
        {
            await _dataService.AddShoppingCartItem(Guid.Parse(productId), (int)qty, "standard");
            await ToastHelper.ShowToast("Item added to cart");
           await _navigationService.NavigateToShoppingCart();

        }       
    }
}
