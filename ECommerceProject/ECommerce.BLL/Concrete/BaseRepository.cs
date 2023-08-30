using ECommerce.BLL.Abstract;
using ECommerce.DAL.Context;
using ECommerce.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : BaseClass
    {
        private readonly ECommerceContext _context;
        private DbSet<T> _entities;
        public BaseRepository(ECommerceContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public string Create(T entity)
        {
            try
            {
                _entities.Add(entity);
                return "Data is Created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var entity = GetbyId(id);
                if (entity != null)
                {
                    entity.Status=Entity.Enum.Status.Deleted;
                    Update(entity);
                    return "Data is Deleted";
                }
                else
                {
                    return "Data is not found";
                }
             }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.Active);
        }

        public T GetbyId(int id)
        {
            return _entities.Find(id);
        }

        public string Update(T entity)
        {
            try
            {
                _context.Entry(entity).State=EntityState.Modified;
                return "Data is Updated";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
