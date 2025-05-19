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

        public ICommand SelectProductCommand { get; }

        private readonly IMediator _mediator;
        public WishListViewModel(IMediator mediator)
        {
            _mediator = mediator;
            SelectProductCommand = new Command<ProductListViewModel>(SelectProduct);
            _ = InitializeAsync();
        }

        private async void SelectProduct(ProductListViewModel model)
        {
            if (model.IsAvailable)
            {
                await MauiApp.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView());
            }
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            Products.Clear();
            var storedProducts = await _mediator.Send(new ProductsQuery());
            Products = storedProducts.Select(x => new ProductListViewModel(x)).ToObservableCollection();
            //Products.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png",IsAvailable = true});
            //Products.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png", IsAvailable = true });
            //Products.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            //Products.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            //Products.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });
            IsLoaded = true;
        }

    }
}
