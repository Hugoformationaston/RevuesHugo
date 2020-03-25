using Microsoft.AspNetCore.Mvc;
using Revues.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revues.Controllers
{
    [ApiController]
    [Route("/auteurs")]
    public class AuteursController
    {
        public AuteursController()
        {
        }

        [HttpGet]
        [Route ("")]
        public IEnumerable<Auteur> FindAll()
        {
            ICollection<Auteur> auteurs = new List<Auteur>();
            Auteur a1 = new Auteur()
            {
                Nom = "Mouchon",
                Prenom = "Hugo",
                Email = "jesaispas@gmail.com"
            };
            Auteur a2 = new Auteur()
            {
                Nom = "Derbomez",
                Prenom = "Thibault",
                Email = "jesaisplus@gmail.com"
            };
            auteurs.Add(a1);
            auteurs.Add(a2);

            return auteurs;
        }
    }
}
