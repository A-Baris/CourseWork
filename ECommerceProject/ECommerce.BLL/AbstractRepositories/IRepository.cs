using ECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Abstract
{
    public interface IRepository<T> where T : BaseClass //every entity is a BaseClass
    {
        //CRUD base functions

        //List
        IEnumerable<T> GetAll();
        //Create
        string Create(T entity);
        //Update
        string Update(T entity);
        //Delete
        string Delete(int id);
        //Get one
        T GetbyId(int id);
    }
}
