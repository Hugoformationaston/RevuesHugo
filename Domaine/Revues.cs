using System;
using System.Collections.Generic;

namespace Revues.Domaine
{
    public partial class Revues
    {
        public Revues()
        {
            Numero = new HashSet<Numero>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime? Annee { get; set; }

        public virtual ICollection<Numero> Numero { get; set; }
    }
}
