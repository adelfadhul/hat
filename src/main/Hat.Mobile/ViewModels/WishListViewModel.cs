using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Queries;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;

namespace Hat.ViewModels
{
    public class WishListViewModel : BaseViewModel
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
        private readonly ProductDetailsView _productDetailsView;
        public WishListViewModel(IMediator mediator, ProductDetailsView productDetailsView)
        {
            _mediator = mediator;
            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            _ = InitializeAsync();
            _productDetailsView = productDetailsView;
        }

        private async void SelectProduct(ProductViewModel model)
        {
            if (model.IsAvailable)
            {
                await MauiApp.Current.MainPage.Navigation.PushModalAsync(_productDetailsView);
            }
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
         
            Products.Clear();
            var storedProducts = await _mediator.Send(new ProductsQuery());
            Products = storedProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();
               IsLoaded = true;
        }

    }
}
