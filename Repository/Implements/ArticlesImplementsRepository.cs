using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class ArticlesImplementsRepository : CrudRepository<Articles>
    {
        private RevueContext context;

        public ArticlesImplementsRepository(RevueContext context)
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
            return this.context.Articles.Select(article => article);
        }
        public Articles FindByID(int id)
        {
            return this.context.Articles
                .Where(article => article.Id == id)
                .First();
        }

        public void Remove(int id)
        {
            this.context.Remove(this.FindByID(id));
            this.context.SaveChanges();
        }

        public Articles Save(Articles model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Articles Update(Articles model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
