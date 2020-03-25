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
    /// exemple d'url en serveur local : "https://localhost:44374/numeros"
    /// Pour rappel, le nom des routes doit OBLIGATOIREMENT être mis aux pluriels et sans majuscule.
    /// </summary>
    [ApiController]
    [Route("/numeros")]
    public class NumerosController : ControllerBase
    {
        /// <summary>
        /// Création de l'attribut "repo" pour l'injection de dépendance
        /// </summary>
        private NumeroImplementsRepository repo;

        /// <summary>
        /// Constructeur qui prend en params "NumeroImplementsRepository repo" pour l'injection de dépendance
        /// </summary>
        /// <param name="repo"></param>
        public NumerosController(NumeroImplementsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// La fonction "FindAll" retourne la fonction "FindAll" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner tous les Numeros.
        /// </summary>
        [HttpGet]
        [Route("")]
        public IEnumerable<Numero> FindAll()
        {
            return this.repo.FindAll();
        }

        /// <summary>
        /// La fonction "Save" du controller retourne la fonction "Save" du repository,
        /// et prend en params l'objet Article qu'il enregistre dans un tableau => [FromBody].
        /// Il fait une requête [HttpPost] qui permet d'ajouter sur le serveur.
        /// </summary>
        /// <param name="n"></param>
        [HttpPost]
        [Route("")]
        public Numero Save([FromBody]Numero n)
        {
            return this.repo.Save(a);
        }

        /// <summary>
        /// La fonction "FindById" retourne la fonction "FindById" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner un Numero via son Id.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public Numero FindById(int id)
        {
            return this.repo.FindByID(id);
        }

        /// <summary>
        /// La fonction "Remove" utilise la fonction "Remove" du service repository et fais une 
        /// requête "HttpDelete" au serveur pour supprimer un Numero via son Id.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public void Remove(int id)
        {
            this.repo.Remove(id);
        }

        /// <summary>
        /// La fonction "Update" retourne la fonction "Update" du service repository et fais une 
        /// requête "HttpPut" au serveur pour modifier un Numero.
        /// </summary>
        [HttpPut]
        [Route("")]
        public Numero Update(Numero n)
        {
            return this.repo.Update(n);
        }
    }
}
