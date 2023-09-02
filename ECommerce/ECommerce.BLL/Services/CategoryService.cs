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
    public class CategoryService : ICategoryService
    {

        private IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }




        public string Create(Category entity)
        {


           return _categoryRepository.Create(entity);
          
        }

        public string Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetbyId(int id)
        {
            return _categoryRepository.GetbyId(id);
        }

        public IEnumerable<Category> GetOfflineCategories()
        {
           return _categoryRepository.GetOffline();
        }

        public string Update(Category entity)
        {
           return _categoryRepository.Update(entity);
        }
    }
}
