using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace WebTestProject.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("category")]
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("category");
            return response.Data;
        }
    }
}
