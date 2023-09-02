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
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplierService(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public string Create(Supplier entity)
        {
            return _supplierRepository.Create(entity);
        }

        public string Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier GetbyId(int id)
        {
            return _supplierRepository.GetbyId(id);
        }

        public string Update(Supplier entity)
        {
           return _supplierRepository.Update(entity);
        }
    }
}
