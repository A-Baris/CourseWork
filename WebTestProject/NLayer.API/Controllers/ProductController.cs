using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IProductService _service;

     
        public ProductController(IMapper mapper, IProductService productService)
        {
           
            _mapper = mapper;
            _service = productService;
        }
        //api/products/GetProductWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory() 
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var product = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(product.ToList());
           
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));        
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetbyIdAsync(id);
            var productDtos = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productDtos = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetbyIdAsync(id);
            await _service.RemoveAsync(product);
          

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
       
    }
}

