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


        private string _selectedSize;
        public string SelectedSize
        {
            get => _selectedSize;
            set
            {
                if (SetProperty(ref _selectedSize, value))
                    UpdateCanAddToCart();
            }
        }

        private Color _selectedColor;
        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (SetProperty(ref _selectedColor, value))
                    UpdateCanAddToCart();
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
               _= PopulateData(productId);//fire and forget
            }
        }
        private bool _canAddToCart;
        public bool CanAddToCart
        {
            get => _canAddToCart;
            set => SetProperty(ref _canAddToCart, value);
        }
        private void UpdateCanAddToCart()
        {
            CanAddToCart = !string.IsNullOrEmpty(SelectedSize) && SelectedColor != default;
        }
        public ProductDetailsViewModel(NavigationService navigationService,DataService dataService):base(navigationService,dataService)
        {
           
            BackCommand = new Command<object>(GoBack);
            FavCommand = new Command<Color>(FavItem);
            AddToCartCommand = new Command<object>(async (obj) => await AddToCart());
            _ = InitializeAsync();
    
        }

        private async Task InitializeAsync()
        {
            await PopulateData(productId);
        }

        async Task PopulateData(string productId)
        {
            if(string.IsNullOrEmpty(productId))
            {
                return;
            }
            var storedProduct = await _dataService.GetProductByIdWithDetails(Guid.Parse(productId));
            ProductDetail = new ProductViewModel(storedProduct);

            IsFavorite = await _dataService.IsFav(Guid.Parse(productId));

            IsLoaded = true;
        }
        private async void GoBack(object obj)
        {
           await _navigationService.GoBack();
        }

        private void FavItem(Color obj)
        {
            if (!IsFavorite)
            {
                _ = _dataService.CreateWish(Guid.Parse(productId));
            }
            else
            {
                _ = _dataService.DeleteWish(Guid.Parse(productId));
            }
           
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
            await _dataService.AddCartItem(Guid.Parse(productId), (int)qty, "standard");
            await ToastHelper.ShowToast("Item added to cart");
           await _navigationService.NavigateToShoppingCart();

        }       
    }
}
