using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class NumeroImplementsRepository : CrudRepository<Numero>
    {
        private RevuesContext context;

        public NumeroImplementsRepository(RevuesContext context)
        {
            this.context = context;
        }

        public IQueryable<Numero> Filter(Numero model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Numero> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Numero.Select(Numero => Numero);
        }
        public Numero FindByID(int id)
        {
            return this.con
        }

        public IQueryable<Numero> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Numero Save(Numero model)
        {
            throw new NotImplementedException();
        }

        public Numero Update(Numero model)
        {
            throw new NotImplementedException();
        }

        Numero CrudRepository<Numero>.FindByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
