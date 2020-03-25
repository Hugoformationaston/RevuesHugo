using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class AuteursImplementsRepository : CrudRepository<Auteurs>
    {
        private RevuesContext context;

        public AuteursImplementsRepository(RevuesContext context)
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
            return this.context.Auteurs.Select(Auteur => Auteur);
        }
        public Auteurs FindByID(int id)
        {
            return this.con
        }

        public IQueryable<Auteurs> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Auteurs Save(Auteurs model)
        {
            throw new NotImplementedException();
        }

        public Auteurs Update(Auteurs model)
        {
            throw new NotImplementedException();
        }

        Auteurs CrudRepository<Auteurs>.FindByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
