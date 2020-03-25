using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Repository
{
    public class ArticlesImplementsRepository : CrudRepository<Article>
    {
        private RevueContext context;

        public ArticlesImplementsRepository(RevueContext context)
        {
            this.context = context;
        }

        public IQueryable<Article> Filter(Article model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindAll()
        {
            //SELECT * FROM Auteurs;
            return this.context.Articles.Select(article => article);
        }
        public Article FindByID(int id)
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

        public Article Save(Article model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }

        public Article Update(Article model)
        {
            this.context.Add(model);
            this.context.SaveChanges();
            return model;
        }
    }
}
