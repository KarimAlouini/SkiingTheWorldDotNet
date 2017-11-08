namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.job_offer")]
    public partial class job_offer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public job_offer()
        {
            job_apply = new HashSet<job_apply>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public DateTime? endDate { get; set; }

        public int? numberOfPlaces { get; set; }

        public double? salary { get; set; }

        public DateTime? startDate { get; set; }

        public int? validity { get; set; }

        public int? agency_id { get; set; }

        public virtual agency agency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<job_apply> job_apply { get; set; }
    }
}
