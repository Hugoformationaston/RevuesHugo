using System;
using System.Collections.Generic;

namespace Revues.Domaine
{
    public partial class Article
    {
        public Article()
        {
            Ecrit = new HashSet<Ecrit>();
            Numero = new HashSet<Numero>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }

        public virtual ICollection<Ecrit> Ecrit { get; set; }
        public virtual ICollection<Numero> Numero { get; set; }
    }
}
