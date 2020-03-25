using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class AuteursImplementsRepository : CrudRepository<Auteur>
    {
        private RevueContext context;

        public AuteursImplementsRepository(RevueContext context)
        {
            this.context = context;
        }

        public IQueryable<Auteur> Filter(Auteur model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Auteur> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Auteurs.Select(auteur => auteur);
        }
        public Auteur FindByID(int id)
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

        public Auteur Save(Auteur model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Auteur Update(Auteur model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
