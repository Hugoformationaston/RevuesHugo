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
        /// <returns>
        /// Si erreur il y a, le Try/Catch renvoi l'erreur 400 "BadRequest"
        /// </returns>
        [HttpGet]
        [Route ("")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(this.repo.FindAll());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// La fonction "Save" du controller retourne la fonction "Save" du repository,
        /// et prend en params l'objet Article qu'il enregistre dans un tableau => [FromBody].
        /// Il fait une requête [HttpPost] qui permet d'ajouter sur le serveur.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// Si erreur il y a, le Try/Catch renvoi l'erreur 400 "BadRequest"
        /// </returns>
        [HttpPost]
        [Route("")]
        public IActionResult Save([FromBody]Article a)
        {   try
            {
                return Ok(this.repo.Save(a));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// La fonction "FindById" retourne la fonction "FindById" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner un Article via son Id.
        /// </summary>
        /// <returns>
        /// Si erreur il y a, le Try/Catch renvoi l'erreur 404 "NotFound"
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindById(int id)
        {
            try
            {
                return Ok(this.repo.FindByID(id));
            }
            catch (IndexOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// La fonction "Remove" utilise la fonction "Remove" du service repository et fais une 
        /// requête "HttpDelete" au serveur pour supprimer un Article via son Id.
        /// </summary>
        /// <returns>
        /// Si erreur il y a, le Try/Catch renvoi l'erreur 404 "NotFound"
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                this.repo.Remove(id);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// La fonction "Update" retourne la fonction "Update" du service repository et fais une 
        /// requête "HttpPut" au serveur pour modifier un Article.
        /// </summary>
        /// <returns>
        /// Si erreur il y a, le Try/Catch renvoi l'erreur 400 "BadRequest"
        /// </returns>
        [HttpPut]
        [Route("")]
        public IActionResult Update(Article a)
        {
            try
            {
                return Ok(this.repo.Update(a));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
