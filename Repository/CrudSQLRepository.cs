using Microsoft.EntityFrameworkCore;
using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class CrudSQLRepository<T> : CrudRepository<T> where T : Model
    {
        private RevueContext context = null;
        private DbSet<T> table = null;
        public CrudSQLRepository(RevueContext context)
        {
            this.context = context;
            this.table = context.Set<T>(); //Context.Article;
        }
        public IQueryable<T> Filter(T model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            return this.table;
        }

        public T FindByID(int id)
        {
            return this.table.Where(model => model.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T model)
        {
            throw new NotImplementedException();
        }

        public T Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
