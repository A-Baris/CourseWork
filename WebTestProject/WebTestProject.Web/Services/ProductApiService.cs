using NLayer.Core.DTOs;
using NLayer.Core.Entity;

namespace WebTestProject.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("product/GetProductWithCategory");
            return response.Data;
        }

        public async Task<ProductDto> CreateAsync(ProductDto product)
        {
            var response = await _httpClient.PostAsJsonAsync("product", product);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(ProductDto product)
        {
            var response = await _httpClient.PutAsJsonAsync("product", product);


            return response.IsSuccessStatusCode;

        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");


            return response.IsSuccessStatusCode;

        }



        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"product/{id}");
            return response.Data;
        }


    }
}
