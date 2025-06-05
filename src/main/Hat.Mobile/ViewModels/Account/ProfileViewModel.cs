using Hat.Domain.Identity;
using Hat.Mobile.Model;
using Hat.Mobile.Services;
using Hat.Mobile.Views;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; } 

        private List<MenuItems> _MenuItems = [];
        public List<MenuItems> MenuItems
        {
            get => _MenuItems;
            set => SetProperty(ref _MenuItems, value);
        }

        private bool _IsLoaded;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        public ICommand SelectMenuCommand { get; }
        private readonly LoginView _loginView;
       
        private readonly ICurrentUser _currentUser;
        public ProfileViewModel(LoginView loginView, NavigationService navigationService,DataService dataService, ICurrentUser currentUser):base(navigationService,dataService)
        {
            _currentUser = currentUser;
            SelectMenuCommand = new Command<MenuItems>(SelectMenu);
            _loginView = loginView;
             InitializeAsync();

        }
        private  void InitializeAsync()
        {
             PopulateDataAsync();
        }
        private void PopulateDataAsync()
        {
             Name=  _currentUser.Name();
            Email = _currentUser.Email();
            ImageUrl = _currentUser.Image();
            MenuItems.Clear();
            //MenuItems.Add(new MenuItems() { Title = "Edit Profile", Body = "\uf3eb" });
            MenuItems.Add(new MenuItems() { Title = "Shipping Address", Body = "\uf34e", TargetType = typeof(ShippingAddressSelectorView) });
            MenuItems.Add(new MenuItems() { Title = "Wishlist", Body = "\uf2d5", TargetType = typeof(WishListView) });
            MenuItems.Add(new MenuItems() { Title = "Order History", Body = "\uf150", TargetType = typeof(OrderDetailsView) });
            MenuItems.Add(new MenuItems() { Title = "Track Order", Body = "\uf787", TargetType = typeof(OrderDetailsView) });
            MenuItems.Add(new MenuItems() { Title = "Cards", Body = "\uf19b", TargetType = typeof(CardInfoManagerView) });
            //MenuItems.Add(new MenuItems() { Title = "Notifications", Body = "\uf09c"});
            MenuItems.Add(new MenuItems() { Title = "Logout", Body = "\uf343", TargetType = typeof(LoginView) });
            if (_currentUser.IsAdmin())
            {
                MenuItems.Add(new MenuItems() { Title = "Create Product", Body = "\uf0e7", TargetType = typeof(CreateProductView) });
                MenuItems.Add(new MenuItems() { Title = "Create Vat", Body = "\uf0e7", TargetType = typeof(CreateVatView) });
                MenuItems.Add(new MenuItems() { Title = "Create Inventory", Body = "\uf0e7", TargetType = typeof(CreateInventoryView) });

            }
            IsLoaded = true;
        }

        private async void SelectMenu(MenuItems item)
        {
            if (item.TargetType !=null )
            {
                if (item.TargetType == typeof(LoginView))
                {
                    var response = await MauiApp.Current.MainPage.DisplayAlert("Logout", "Do you want to logout?", "Yes", "No");
                    if (response)
                        MauiApp.Current.MainPage = _loginView;
                }
                else
                {
                    //  await MauiApp.Current.MainPage.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                    switch (item.TargetType)
                    {
                        case Type type when type == typeof(ShippingAddressSelectorView):
                            await _navigationService.NavigateToShippingAddress();
                            break;
                        case Type type when type == typeof(WishListView):
                            await _navigationService.NavigateToWhishList();
                            break;
                        case Type type when type == typeof(OrderDetailsView):
                            await _navigationService.NavigateToOrderDetails();
                            break;
                        case Type type when type == typeof(CardInfoManagerView):
                            await _navigationService.NavigateToCard();
                            break;
                        case Type type when type == typeof(CreateProductView):
                            await _navigationService.NavigateToCreateProduct();
                            break;
                        case Type type when type == typeof(CreateVatView):
                            await _navigationService.NavigateToCreateVat();
                            break;
                        case Type type when type == typeof(CreateInventoryView):
                            await _navigationService.NavigateToCreateInventory();
                            break;
                        default:
                            break;
                    }
                
                }
            }
            
        }       
    }
}
