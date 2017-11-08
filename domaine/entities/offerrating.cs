namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.offerrating")]
    public partial class offerrating
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? value { get; set; }

        public int? offer_id { get; set; }

        public int? user_id { get; set; }

        public virtual offer offer { get; set; }

        public virtual user user { get; set; }
    }
}
