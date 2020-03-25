using System;
using System.Collections.Generic;

namespace Revues.Domaine
{
    public partial class Auteur
    {
        public Auteur()
        {
            Ecrit = new HashSet<Ecrit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Ecrit> Ecrit { get; set; }
    }
}
