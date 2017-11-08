namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.agency")]
    public partial class agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agency()
        {
            job_offer = new HashSet<job_offer>();
            establishment = new HashSet<establishment>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? agent_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<job_offer> job_offer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<establishment> establishment { get; set; }

        public virtual user user { get; set; }
    }
}
