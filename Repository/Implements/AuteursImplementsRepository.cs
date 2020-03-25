using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class AuteursImplementsRepository : CrudRepository<Auteurs>
    {
        private RevueContext context;

        public AuteursImplementsRepository(RevueContext context)
        {
            this.context = context;
        }

        public IQueryable<Auteurs> Filter(Auteurs model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Auteurs> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Auteurs.Select(auteur => auteur);
        }
        public Auteurs FindByID(int id)
        {
            return this.context.Auteurs
                .Where(auteur => auteur.Id == id)
                .First();
        }

        public void Remove(int id)
        {
            this.context.Remove(this.FindByID(id));
            this.context.SaveChanges();
        }

        public Auteurs Save(Auteurs model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Auteurs Update(Auteurs model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
