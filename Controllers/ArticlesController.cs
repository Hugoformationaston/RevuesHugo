using Microsoft.AspNetCore.Mvc;
using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Controllers
{
    using Domaine;

    [ApiController]
    [Route("/articles")]
    public class ArticlesController
    {
        public ArticlesController()
        {
        }

        [HttpGet]
        [Route ("")]
        public IEnumerable<Article> FindAll()
        {
            ICollection<Article> articles = new List<Article>();
            Article a1 = new Article()
            {
                Titre = "La Paix",
                Contenu ="Guerre et paix édité chez plomb"
            };
            Article a2 = new Article()
            {
                Titre = "La guerre",
                Contenu = "c'est très très mal la guerre, vue du dessus"
            };
            articles.Add(a1);
            articles.Add(a2);

            return articles;
        }
        [HttpPost]
        [Route("")]
        public Article Save(Article a)
        {

        }
    }
}
