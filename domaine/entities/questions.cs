namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public questions()
        {
            test = new HashSet<test>();
        }

        [Key]
        public int questionID { get; set; }

        [StringLength(255)]
        public string rightAnswer { get; set; }

        [StringLength(255)]
        public string statement { get; set; }

        [StringLength(255)]
        public string wrongAnwer1 { get; set; }

        [StringLength(255)]
        public string wrongAnwer2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> test { get; set; }
    }
}
