using ECommerce.BLL.Abstracts;
using ECommerce.BLL.AbstractServices;
using ECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }



        public string Create(Product entity)
        {
            return _productRepository.Create(entity);
        }

        public string Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetbyId(int id)
        {
            return _productRepository.GetbyId(id);
        }

        public IEnumerable<Product> GetOfflineProducts()
        {
            return _productRepository.GetOffline();
        }

        public string Update(Product entity)
        {
           return _productRepository.Update(entity);
        }

        //custom methods
    }
}
