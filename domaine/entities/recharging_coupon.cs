namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class recharging_coupon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? amount { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        public DateTime? dateGenerated { get; set; }

        [Column(TypeName = "bit")]
        public bool? isUsed { get; set; }
    }
}
