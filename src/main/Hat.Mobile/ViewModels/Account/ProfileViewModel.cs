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
       
        private readonly ILoginService _loginService;
        public ProfileViewModel(LoginView loginView, NavigationService navigationService,DataService dataService, ILoginService loginService):base(navigationService,dataService)
        {
            _loginService = loginService;
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
            var currentUser=_loginService.GetCurrentUser();
            Name =  currentUser.Name();
            Email = currentUser.Email();
            ImageUrl = currentUser.Image();
            MenuItems.Clear();
            //MenuItems.Add(new MenuItems() { Title = "Edit Profile", Body = "\uf3eb" });
            MenuItems.Add(new MenuItems() { Title = "Shipping Address", Body = "\uf34e", TargetType = typeof(ShippingAddressSelectorView) });
            MenuItems.Add(new MenuItems() { Title = "Wishlist", Body = "\uf2d5", TargetType = typeof(WishListView) });
            MenuItems.Add(new MenuItems() { Title = "Order History", Body = "\uf150", TargetType = typeof(OrderListView) });
            MenuItems.Add(new MenuItems() { Title = "Track Order", Body = "\uf787", TargetType = typeof(OrderListView) });
            MenuItems.Add(new MenuItems() { Title = "Cards", Body = "\uf19b", TargetType = typeof(CardManagerView) });
            //MenuItems.Add(new MenuItems() { Title = "Notifications", Body = "\uf09c"});
            MenuItems.Add(new MenuItems() { Title = "Logout", Body = "\uf343", TargetType = typeof(LoginView) });
            if (currentUser.IsAdmin())
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
                        case Type type when type == typeof(OrderListView):
                            await _navigationService.NavigateToOrderDetails();
                            break;
                        case Type type when type == typeof(CardManagerView):
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
