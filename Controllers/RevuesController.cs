﻿using Microsoft.AspNetCore.Mvc;
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
    /// exemple d'url en serveur local : "https://localhost:44374/revues"
    /// Pour rappel, le nom des routes doit OBLIGATOIREMENT être mis aux pluriels et sans majuscule.
    /// </summary>
    [ApiController]
    [Route("/revues")]
    public class RevuesController : ControllerBase
    {
        /// <summary>
        /// Création de l'attribut "repo" pour l'injection de dépendance
        /// </summary>
        private RevuesImplementsRepository repo;

        /// <summary>
        /// Constructeur qui prend en params "RevuesImplementsRepository repo" pour l'injection de dépendance
        /// </summary>
        /// <param name="repo"></param>
        public RevuesController(RevuesImplementsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// La fonction "FindAll" retourne la fonction "FindAll" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner tous les Revues.
        /// </summary>
        [HttpGet]
        [Route("")]
        public IEnumerable<Revues> FindAll()
        {
            return this.repo.FindAll();
        }

        /// <summary>
        /// La fonction "Save" du controller retourne la fonction "Save" du repository,
        /// et prend en params l'objet Revues qu'il enregistre dans un tableau => [FromBody].
        /// Il fait une requête [HttpPost] qui permet d'ajouter sur le serveur.
        /// </summary>
        /// <param name="r"></param>
        [HttpPost]
        [Route("")]
        public Revues Save([FromBody]Revues r)
        {
            return this.repo.Save(r);
        }

        /// <summary>
        /// La fonction "FindById" retourne la fonction "FindById" du service repository et fais une 
        /// requête "HttpGet" au serveur pour retourner une Revue via son Id.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public Revues FindById(int id)
        {
            return this.repo.FindByID(id);
        }

        /// <summary>
        /// La fonction "Remove" utilise la fonction "Remove" du service repository et fais une 
        /// requête "HttpDelete" au serveur pour supprimer une Revue via son Id.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public void Remove(int id)
        {
            this.repo.Remove(id);
        }

        /// <summary>
        /// La fonction "Update" retourne la fonction "Update" du service repository et fais une 
        /// requête "HttpPut" au serveur pour modifier une Revue.
        /// </summary>
        [HttpPut]
        [Route("")]
        public Revues Update(Revues r)
        {
            return this.repo.Update(r);
        }
    }
}
