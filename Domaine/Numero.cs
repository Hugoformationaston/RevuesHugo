using System;
using System.Collections.Generic;

namespace Revues.Domaine
{
    public partial class Numero
    {
        public int ArticlesId { get; set; }
        public int RevuesId { get; set; }
        public int? PageDebut { get; set; }
        public int? PageFin { get; set; }
        public int Id { get; set; }

        public virtual Article Articles { get; set; }
        public virtual Revues Revues { get; set; }
    }
}
