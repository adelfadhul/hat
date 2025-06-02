using Camera.MAUI.ZXingHelper;
using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using Hat.Mobile.Views;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;

namespace Hat.Mobile.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<CategoryViewModel> _Categories = [];
        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _Categories;
            set => SetProperty(ref _Categories, value);

        }

        private ObservableCollection<ProductViewModel> _BestSellingProducts = [];
        public ObservableCollection<ProductViewModel> BestSellingProducts
        {
            get => _BestSellingProducts;
            set => SetProperty(ref _BestSellingProducts, value);
        }

        private ObservableCollection<ProductViewModel> _FeaturedBrands = [];
        public ObservableCollection<ProductViewModel> FeaturedBrands
        {
            get => _FeaturedBrands;
            set => SetProperty(ref _FeaturedBrands, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand SelectProductCommand { get; }
        public ICommand BrandTapCommand { get; }
        public ICommand RecommendedTapCommand { get; }
        public ICommand CategoryTapCommand { get; }
        public ICommand OpenCameraCommand { get; }





        private readonly ILogger<HomePageViewModel> _logger;
        public HomePageViewModel(NavigationService navigationService, DataService dataService, ILogger<HomePageViewModel> logger):base(navigationService,dataService)
        {
            _logger = logger;

            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            RecommendedTapCommand = new Command<object>(SelectRecommend);
            CategoryTapCommand = new Command<CategoryViewModel>(SelectCategory);
            BrandTapCommand = new Command<ProductViewModel>(SelectBrand);
            OpenCameraCommand = new Command(OpenCamera);
            _ = InitializeAsync();

        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async Task PopulateDataAsync()
        {
          //  try
          //  {

                _logger.LogInformation("Fetching categories");
                var storedCategories = await _dataService.GetCategories();

                _logger.LogInformation("Fetched categories");
                Categories = storedCategories.Select(x => new CategoryViewModel(x)).ToObservableCollection();



                var bestSellingProducts = await _dataService.GetBestSellingProducts();
                BestSellingProducts = BestSellingProducts = bestSellingProducts
                    .Select(x => new ProductViewModel(x)).ToObservableCollection();

                var storedFeaturedBrandsProducts = await _dataService.GetFeaturedProducts();
                FeaturedBrands = storedFeaturedBrandsProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();

         //   }
         //   catch (Exception ex)
          //  {
                
              //  _logger.LogError(ex, "Error fetching categories");
              //  var msg = "An error occurred while fetching data. Please try again later "+ex.Message;
                //await MauiApp.Current.MainPage.DisplayAlert("Error", msg, "OK");
           // }
            IsLoaded = true;
        }

        private async void SelectBrand(ProductViewModel product)
        => await _navigationService.NavigateToBrandDetail();

        private async void SelectProduct(ProductViewModel product)
        => await _navigationService.NavigateToProductDetails(product.Id);

        private async void SelectCategory(CategoryViewModel category)
        => await _navigationService.NavigateToCategoryDetails(category.CategoryID);

        private async void SelectRecommend(object product)
        => await _navigationService.NavigateToAllProducts();
        private async void OpenCamera()
        {
            var response = await MauiApp.Current.MainPage.DisplayAlert("Scan QR", "Do you want to open camera?", "Yes", "No");
            if (response)
            {
                PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status == PermissionStatus.Granted)
                {
                    await MauiApp.Current.MainPage.Navigation.PushModalAsync(new ScanCameraView());
                }
                else
                {
                    await MauiApp.Current.MainPage.DisplayAlert("Permission Denied", "Camera access is required but not granted. Please enable camera permissions in your device settings.", "OK");

                }

            }
        }

        private void CameraViewBarcodeDetected(object sender, BarcodeEventArgs args)
        {

        }

        private void CameraViewCamerasLoaded(object sender, EventArgs e)
        {

        }
    }
}
