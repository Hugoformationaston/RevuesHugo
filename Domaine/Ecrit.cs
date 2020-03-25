using System;
using System.Collections.Generic;

namespace Revues.Domaine
{
    public partial class Ecrit
    {
        public int AuteursId { get; set; }
        public int ArticlesId { get; set; }

        public virtual Article Articles { get; set; }
        public virtual Auteur Auteurs { get; set; }
    }
}
