using Hat.Domain.Models;
using System.Net.Http.Json;

namespace Hat.Services
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
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");
        }
        public async Task<List<ProductModel>> GetFeaturedProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products/featured");
        }

        public async Task<List<ProductModel>> GetBestSellingProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products/best-selling");
        }
        public async Task<ProductModel> GetProductById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/{id}");
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryModel>>("api/categories");
        }

        public async Task<List<DeliveryTypeModel>> GetDeliveryTypes()
        {
            return await _httpClient.GetFromJsonAsync<List<DeliveryTypeModel>>("api/delivery-types");
        }

        // Add more methods as needed for other endpoints

        public async Task<List<string>> getBrands()
        {
            var brands = await _httpClient.GetFromJsonAsync<List<string>>("api/brands");
            return brands;
        }

        internal async Task<List<CardInfoModel>> GetCardInfos()
        {
            var cards= await _httpClient.GetFromJsonAsync<List<CardInfoModel>>("api/card-infos");
            return cards;
        }

        internal async Task<List<TrackModel>> GetTracks()
        {
            return await _httpClient.GetFromJsonAsync<List<TrackModel>>("api/trackorders");
        }

        internal async Task<List<ShippingAddressModel>> GetShippingAddresses()
        {
           return await _httpClient.GetFromJsonAsync<List<ShippingAddressModel>>("api/shipping-address");
        }

        internal async Task<List<DeliveryStepModel>> GetDeliverySteps()
        {
           return await _httpClient.GetFromJsonAsync<List<DeliveryStepModel>>("api/delivery-steps");
        }
    }
}
