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
        private readonly ProductDetailsView _productDetailsView;
        public AllProductViewModel(IMediator mediator, HttpClient httpClient, ProductDetailsView productDetailsView )
        {
            _mediator = mediator;
            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            _ = InitializeAsync();
            _httpClient = httpClient;
            _productDetailsView = productDetailsView;
        }
        public AllProductViewModel() { }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            
            var storedProducts= await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");
            Products.Clear();
            Products = storedProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();    
            foreach (var x in storedProducts)
            IsLoaded = true;
        }

        private async void SelectProduct(ProductViewModel product)
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushModalAsync(_productDetailsView);
        }
    }
}
