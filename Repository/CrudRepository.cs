using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public interface CrudRepository<T>
    {
        public IQueryable<T> Filter(T model);
        public IQueryable<T> FindAll();
        public T FindByID(int id);
        public void Remove(int id);
        public T Update(T model);
        public T Save(T model);   
    }
}
