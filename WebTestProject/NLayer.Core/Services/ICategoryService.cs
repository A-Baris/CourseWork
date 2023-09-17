using NLayer.Core.DTOs;
using NLayer.Core.Entity;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductDto>> GetsingleCategoryByIdWithProductAsync(int categoryId);
    }
}
