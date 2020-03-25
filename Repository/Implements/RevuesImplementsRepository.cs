using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class RevuesImplementsRepository : CrudRepository<Domaine.Revues>
    {
        private RevueContext context;

        public RevuesImplementsRepository(RevueContext context)
        {
            this.context = context;
        }

        public IQueryable<Domaine.Revues> Filter(Domaine.Revues model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domaine.Revues> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Revues.Select(revue => revue);
        }
        public Domaine.Revues FindByID(int id)
        {
            return this.context.Revues
                .Where(revue => revue.Id == id)
                .First();
        }

        public void Remove(int id)
        {
            this.context.Remove(this.FindByID(id));
            this.context.SaveChanges();
        }

        public Domaine.Revues Save(Domaine.Revues model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Domaine.Revues Update(Domaine.Revues model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
