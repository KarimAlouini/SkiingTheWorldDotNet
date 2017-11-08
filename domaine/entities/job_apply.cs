namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.job_apply")]
    public partial class job_apply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DateTime? applicationDate { get; set; }

        [StringLength(255)]
        public string message { get; set; }

        public int? offer_id { get; set; }

        public int? user_id { get; set; }

        public virtual job_offer job_offer { get; set; }

        public virtual user user { get; set; }
    }
}
