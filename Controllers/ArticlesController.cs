using Microsoft.AspNetCore.Mvc;
using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Controllers
{
    using Domaine;
    using Revues.Repository;

    /// <summary>
    /// Route "/articles" permet d'accéder aux fonctions liées à celui çi depuis l'url.
    /// exemple d'url en serveur local : "https://localhost:44374/articles"
    /// Pour rappel, le nom des routes doit OBLIGATOIREMENT être mis aux pluriels et sans majuscule.
    /// </summary>
    [ApiController]
    [Route("/articles")]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// Création de l'attribut "repo" pour l'injection de dépendance
        /// </summary>
        private ArticlesImplementsRepository repo;

        /// <summary>
        /// Constructeur qui prend en params "ArticlesImplementsRepository repo" pour l'injection de dépendance
        /// </summary>
        /// <param name="repo"></param>
        public ArticlesController(ArticlesImplementsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// La fonction "FindAll" retourne la fonction "FindAll" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner tous les Articles.
        /// </summary>
        [HttpGet]
        [Route ("")]
        public IEnumerable<Article> FindAll()
        {
            return this.repo.FindAll();
        }

        /// <summary>
        /// La fonction "Sauvegarde" du controller retourne la fonction "Save" du repository,
        /// et prend en params l'objet Article qu'il enregistre dans un tableau => [FromBody].
        /// Il fait une requête [HttpPost] qui permet d'ajouter sur le serveur.
        /// </summary>
        /// <param name="a"></param>
        [HttpPost]
        [Route("")]
        public Article Save([FromBody]Article a)
        {
            return this.repo.Save(a);
        }

        /// <summary>
        /// La fonction "FindById" retourne la fonction "FindById" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner un Article via son Id.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public Article FindById(int id)
        {
            return this.repo.FindByID(id);
        }

        /// <summary>
        /// La fonction "Delete" utilise la fonction "Delete" du service repository et fais une 
        /// requête "HttpDelete" au serveur pour supprimer un Article via son Id.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public void Remove(int id)
        {
            this.repo.Remove(id);
        }

        /// <summary>
        /// La fonction "Update" retourne la fonction "Update" du service repository et fais une 
        /// requête "HttpPut" au serveur pour modifier un Article.
        /// </summary>
        [HttpPut]
        [Route("")]
        public Article Update(Article a)
        {
            return this.repo.Update(a);
        }
    }
}
