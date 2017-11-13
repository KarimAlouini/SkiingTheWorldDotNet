namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class establishment
    {
        [Required]
        [StringLength(31)]
        public string DTYPE { get; set; }

        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public double? latidue { get; set; }

        public double? longitude { get; set; }

        public int? classification { get; set; }

        public int? nbrLit { get; set; }

        public int? nbrPers { get; set; }

        [StringLength(255)]
        public string nomResort { get; set; }

        public int? prixNuit { get; set; }

        public int? nbrchambres { get; set; }

        [StringLength(255)]
        public string nomChalet { get; set; }

        public int? agency { get; set; }

        public virtual agency agency1 { get; set; }
    }
}
