using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class ArticlesImplementsRepository : CrudRepository<Articles>
    {
        private RevuesContext context;

        public ArticlesImplementsRepository(RevuesContext context)
        {
            this.context = context;
        }

        public IQueryable<Articles> Filter(Articles model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Articles> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Articles.Select(Article => Article);
        }
        public Articles FindByID(int id)
        {
            return this.con
        }

        public IQueryable<Articles> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Articles Save(Articles model)
        {
            throw new NotImplementedException();
        }

        public Articles Update(Articles model)
        {
            throw new NotImplementedException();
        }

        Articles CrudRepository<Articles>.FindByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
