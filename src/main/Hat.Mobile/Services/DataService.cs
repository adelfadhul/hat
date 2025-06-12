using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Mobile.ViewModels;
using System.Net;
using System.Net.Http.Json;

namespace Hat.Mobile.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;
        private ICurrentUser _currentUser;
        private readonly ILoginService _loginService;
       
        public DataService(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
            _loginService = loginService;


        }
        public async Task<List<ProductModel>> GetUserWishProducts()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync($"/api/products/user/wish");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching user wish products: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return data;
        }
        public async Task<List<ProductModel>> GetProducts()
        {
            var response = await _httpClient.GetAsync("/api/products");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching products: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return data;
        }



        public async Task<List<ProductModel>> GetFeaturedProducts()
        {
            var response = await _httpClient.GetAsync("/api/products/featured-brand");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching featured products: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return data;
        }

        public async Task<List<ProductModel>> GetBestSellingProducts()
        {
            var response = await _httpClient.GetAsync("/api/products/best-selling");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching best selling products: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return data;
        }

        private async Task<ProductModel> getProductById(Guid id, bool isDetailed)
        {
            var url = isDetailed ? $"/api/products/{id}?detailed=true" : $"/api/products/{id}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching product by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<ProductModel>();
            return data;
        }
        public async Task<ProductModel> GetProductByIdWithDetails(Guid id)
        => await getProductById(id, true);
        public async Task<ProductModel> GetProductById(Guid id)
            => await getProductById(id, false);

        public async Task<List<CategoryModel>> GetCategories()
        {
            var response = await _httpClient.GetAsync("/api/categories");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching categories: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<CategoryModel>>();
            return data;
        }

        public async Task<List<DeliveryTypeModel>> GetDeliveryTypes()
        {
            var response = await _httpClient.GetAsync("/api/delivery-types");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching delivery types: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<DeliveryTypeModel>>();
            return data;
        }

        public async Task<List<string>> getBrands()
        {
            var response = await _httpClient.GetAsync("/api/brands");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching brands: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<string>>();
            return data;
        }

        internal async Task<List<CardModel>> GetUserCards()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync("/api/cards/user");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching card infos: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<CardModel>>();
            return data;
        }
        internal async Task<Guid> CreateCard(CardModel card)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/cards", card);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating card: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<Guid>();
            return data;
        }

        internal async Task<List<OrderModel>> GetUserOrders()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync("/api/orders/user");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching  orders: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<OrderModel>>();
            return data;
        }

        internal async Task<List<ShippingAddressModel>> GetUserShippingAddresses()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync("/api/shipping-addresses/user");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching shipping addresses: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ShippingAddressModel>>();
            return data;
        }

        internal async Task<List<DeliveryStepModel>> GetDeliverySteps(Guid OrderId)
        {
            var response = await _httpClient.GetAsync($"/api/delivery-steps/{OrderId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching delivery steps: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<DeliveryStepModel>>();
            return data;
        }

        internal async Task AddCartItem(Guid productId, int quantity, string size)
        {
            var payload = new AddCartItemCommand(productId, quantity, size);
            var response = await _httpClient.PostAsJsonAsync("api/carts/add", payload);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error adding shopping cart item: {response.ReasonPhrase}");
            }
        }


        internal async Task<List<CartItemModel>> GetShoppingCartItems()
        {
            var userid = _currentUser.Oid();
            var response = await _httpClient.GetAsync($"/api/cartitems/{userid}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching shopping cart items: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<CartItemModel>>();
            return data;
        }

        internal async Task RemoveShoppingCartItem(Guid itemId)
        {
            var response = await _httpClient.DeleteAsync($"/api/cartitems/{itemId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error removing shopping cart item: {response.ReasonPhrase}");
            }
        }

        public async Task CreateProduct(ProductModel product)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/products", product);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating product: {response.ReasonPhrase}");
            }
        }

        public async Task CreateVat(TaxModel vat)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/taxes", vat);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating product: {response.ReasonPhrase}");
            }
        }

        public async Task<List<ProductModel>> GetProductsByCategory(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"/api/products/category/{categoryId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching products by category: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return data;
        }
        public async Task<CategoryModel?> GetCategoryById(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"/api/categories/{categoryId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching category by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<CategoryModel>();
            return data;
        }

        internal async Task<ShippingAddressModel> GetPrimaryAddress()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync($"/api/shipping-addresses/user/primary");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching category by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<ShippingAddressModel>();
            return data;
        }

        internal async Task<List<TaxModel>> GetUserVats()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync("/api/taxes/user");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching VATs: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<TaxModel>>();
            return data;
        }

        internal async Task<TaxModel?> GetVat(Guid taxId)
        {
            var response = await _httpClient.GetAsync($"/api/taxes/{taxId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching VAT by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<TaxModel>();
            return data;
        }

        internal async Task<Guid> CreateWish(Guid productId)
        {
            AddUserHeader();
            var userid = _loginService.GetCurrentUser().Oid();
            var command = new CreateWishCommand(userid, productId);
            var response = await _httpClient.PostAsJsonAsync("/api/wishes/user", command);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating wish: {response.ReasonPhrase}");
            }
            var wishId = await response.Content.ReadAsStringAsync();
            return Guid.Parse(wishId);
        }
        internal async Task DeleteWish(Guid wishId)
        {
            var response = await _httpClient.DeleteAsync($"/api/wishes/{wishId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error removing wish: {response.ReasonPhrase}");
            }
        }

        internal async Task<WishModel?> GetUserWishByProduct(Guid productId)
        {
            AddUserHeader();
            var userid = _loginService.GetCurrentUser().Oid();
            var response = await _httpClient.GetAsync($"/api/wishes/user/product/{productId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching wish by user and product: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<WishModel>();
            return data;
        }
        internal async Task<List<WishModel>> GetWishesByUser()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync($"/api/wishes/user");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching wishes: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<WishModel>>();
            return data;

        }

        // Pseudocode:
        // 1. The IsFav method throws an exception if an unexpected HTTP status code is returned or if an error occurs.
        // 2. However, if the calling code (or a global handler) catches this exception, the app will not "break" (crash).
        // 3. In .NET MAUI, unhandled exceptions may be caught by the framework or by your own try/catch blocks in the UI layer.
        // 4. To make the app "break" in Visual Studio, ensure you have "Break on all exceptions" enabled, or do not catch the exception in the calling code.

        internal async Task<bool> IsFav(Guid productId)
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync($"/api/wishes/user/product/{productId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error checking if product is fav: {response.ReasonPhrase}");
            }
            return false;
        }

        internal async Task<List<InventoryModel>> GetInventoriesByProduct(Guid productId)
        {
            var response = await _httpClient.GetAsync($"/api/inventories/product/{productId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching inventories by product: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<InventoryModel>>();
            return data;
        }

        internal async Task<Guid> CreateUserInventory(InventoryModel inventory)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/inventories", inventory);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating inventory: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<Guid>();
            return data;
        }

        private void AddUserHeader()
        {
            var userId = _loginService.GetCurrentUser().Oid().ToString();
            // Remove existing "hat-user" header if present to prevent duplicates
            if (_httpClient.DefaultRequestHeaders.Contains("hat-user"))
            {
                _httpClient.DefaultRequestHeaders.Remove("hat-user");
            }
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("hat-user", userId);
        }
        internal async Task<CartModel?> GetUserCart()
        {
            AddUserHeader();
            var response = await _httpClient.GetAsync($"/api/carts/user");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching cart: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<CartModel>();
            return data;
        }

        internal ICurrentUser Login(string email, string password)
        {
            _currentUser = _loginService.Login(email, password);
            AddUserHeader();
            return _currentUser;
        }
    }
}
