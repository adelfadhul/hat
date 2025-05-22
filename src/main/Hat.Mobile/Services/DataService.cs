using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hat.Domain.Models;

namespace Hat.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductModel>($"api/products/{id}");
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryModel>>("api/categories");
        }

        public async Task<List<DeliveryTypeModel>> GetDeliveryTypesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DeliveryTypeModel>>("api/delivery-types");
        }

        // Add more methods as needed for other endpoints
    }
}
