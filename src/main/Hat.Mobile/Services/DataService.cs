using Hat.Domain.Commands;
using Hat.Domain.Identity;
using Hat.Domain.Models;
using System.Net.Http.Json;

namespace Hat.Mobile.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;
        private ICurrentUser _currentUser;

        public DataService(IHttpClientFactory httpClientFactory, ICurrentUser currentUser)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
            _currentUser = currentUser;
        }
        public async Task<List<ProductModel>> GetUserWishProducts()
        {
            var response = await _httpClient.GetAsync($"/api/products/wish/{_currentUser.Oid()}");
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

        internal async Task<List<CardModel>> GetCards()
        {
            var response = await _httpClient.GetAsync("/api/cards");
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

        internal async Task<List<OrderModel>> GetOrders()
        {
            var response = await _httpClient.GetAsync("/api/orders");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching  orders: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<OrderModel>>();
            return data;
        }

        internal async Task<List<ShippingAddressModel>> GetShippingAddresses()
        {
            var response = await _httpClient.GetAsync("/api/shipping-address");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching shipping addresses: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ShippingAddressModel>>();
            return data;
        }

        internal async Task<List<DeliveryStepModel>> GetDeliverySteps()
        {
            var response = await _httpClient.GetAsync("/api/delivery-steps");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching delivery steps: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<DeliveryStepModel>>();
            return data;
        }

        internal async Task AddShoppingCartItem(Guid productId, int quantity, string size)
        {
            var payload = new AddShoppingCartItemCommand(productId, quantity, size);
            var response = await _httpClient.PostAsJsonAsync("api/shopping-cart/add", payload);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error adding shopping cart item: {response.ReasonPhrase}");
            }
        }
        internal async Task<List<ShoppingCartItemModel>> GetShoppingCartItems()
        {
            var response = await _httpClient.GetAsync("/api/shopping-cart");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching shopping cart items: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<ShoppingCartItemModel>>();
            return data;
        }

        internal async Task RemoveShoppingCartItem(Guid itemId)
        {
            var response = await _httpClient.DeleteAsync($"/api/shoppingcart/items/{itemId}");
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

        public async Task CreateVat(VatModel vat)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/vats", vat);
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
            var response = await _httpClient.GetAsync($"/api/shipping-addresses/primary/{_currentUser.Oid()}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching category by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<ShippingAddressModel>();
            return data;
        }

        internal async Task<List<VatModel>> GetVats()
        {
            var response = await _httpClient.GetAsync("/api/vats");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching VATs: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<VatModel>>();
            return data;
        }

        internal async Task<VatModel?> GetVat(Guid vatId)
        {
            var response = await _httpClient.GetAsync($"/api/vats/{vatId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching VAT by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<VatModel>();
            return data;
        }

        internal async Task CreateWish(Guid productId)
        {
            var wish = new WishModel
            {
                UserId = _currentUser.Oid(),
                ProductId = productId
            };
            var response = await _httpClient.PostAsJsonAsync("/api/wishes", wish);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating product: {response.ReasonPhrase}");
            }
        }
        internal async Task DeleteWish(Guid wishId)
        {
            var response = await _httpClient.DeleteAsync($"/api/wishes/{wishId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error removing wish: {response.ReasonPhrase}");
            }
        }

        internal async Task<List<WishModel>> GetWishesByUser()
        {
            var response = await _httpClient.GetAsync($"/api/wishes/{_currentUser.Oid()}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching wishes: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<WishModel>>();
            return data;

        }

        internal async Task<bool> IsFav(Guid productId)
        {
            var response = await _httpClient.GetAsync($"/api/wishes/{_currentUser.Oid()}/products/{productId}");
            // return false if not found
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true; // Wish exists
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

        internal async Task<Guid> CreateInventory(InventoryModel inventory)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/inventories", inventory);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error creating inventory: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<Guid>();
            return data;
        }
    }
}
