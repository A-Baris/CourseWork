using ECommerce.BLL.Abstracts;
using ECommerce.DAL.Context;
using ECommerce.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseClass
    {
        private readonly EcommerceContext _context;
        private DbSet<T> _entities;

        public BaseRepository(EcommerceContext context)
        {
           _context = context;
            _entities = _context.Set<T>();
        }

        public string Create(T entity)
        {
            try
            {
               
                _entities.Add(entity);
                _context.SaveChanges();
                return "veri kaydedildi";
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
                    entity.Status = Entity.Enum.Status.Deleted;
                    Update(entity);
                    return "veri silindi!";
                }
                else
                {
                    return "silinecek veri bulunamadı!";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.Active).ToList();
        }

        public T GetbyId(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetOffline()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.Deleted).ToList();
        }

        public string Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return "veri güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
