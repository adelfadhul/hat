using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class AllProductViewModel : BaseViewModel
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
        public ICommand SelectProductCommand { get; }

        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public AllProductViewModel(NavigationService navigationService, IMediator mediator, IHttpClientFactory httpClientFactory )
        {
            _httpClient = httpClientFactory.CreateClient("Default");
            _mediator = mediator;
            _navigationService = navigationService;
            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            _ = InitializeAsync();
           
        }
        public AllProductViewModel() { }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            var storedProducts= await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/products");
            Products = storedProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();    
            IsLoaded = true;
        }

        private async void SelectProduct(ProductViewModel product)
        {
            await _navigationService.NavigateToProductDetails(product.Id);
        }
    }
}
