using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class NumeroImplementsRepository : CrudRepository<Numero>
    {
        private RevueContext context;

        public NumeroImplementsRepository(RevueContext context)
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
            return this.context.Numero.Select(numero => numero);
        }
        public Numero FindByID(int id)
        {
            return this.context.Numero
                .Where(numero => numero.Id == id)
                .First();
        }

        public void Remove(int id)
        {
            this.context.Remove(this.FindByID(id));
            this.context.SaveChanges();
        }

        public Numero Save(Numero model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Numero Update(Numero model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
