using Hat.Domain.Models;
using System.Net.Http.Json;

namespace Hat.Mobile.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
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

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/products/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching product by id: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<ProductModel>();
            return data;
        }

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

        internal async Task<List<CardInfoModel>> GetCardInfos()
        {
            var response = await _httpClient.GetAsync("/api/card-infos");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching card infos: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<CardInfoModel>>();
            return data;
        }

        internal async Task<List<TrackModel>> GetTracks()
        {
            var response = await _httpClient.GetAsync("/api/trackorders");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching track orders: {response.ReasonPhrase}");
            }
            var data = await response.Content.ReadFromJsonAsync<List<TrackModel>>();
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

        internal async Task AddShoppingCartItem(Guid productId, int quantity)
        {
            var payload = new
            {
                ProductId = productId,
                Quantity = quantity
            };
            var response = await _httpClient.PostAsJsonAsync("/api/shoppingcart/items", payload);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error adding shopping cart item: {response.ReasonPhrase}");
            }
        }
        internal async Task<List<ShoppingCartItemModel>> GetShoppingCartItems()
        {
            var response = await _httpClient.GetAsync("/api/shoppingcart/items");
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
    }
}
