using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class RevuesImplementsRepository : CrudRepository<Revue>
    {
        private RevuesContext context;

        public RevuesImplementsRepository(RevuesContext context)
        {
            this.context = context;
        }

        public IQueryable<Revue> Filter(Revue model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Revue> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Revue.Select(Revue => Revue);
        }
        public Revue FindByID(int id)
        {
            return this.context.Revue.Find(id);
        }

        public IQueryable<Revue> Remove(int id)
        {
            Revue model = this.FindByID(id);
            this.context.Remove(model);
        }

        public Revue Save(Revue model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Revue Update(Revue model)
        {
            throw new NotImplementedException();
        }

        Numero CrudRepository<Numero>.FindByID(int id)
        {
            return this.context.Revue.Find(id);
        }
    }
}
