namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.course_notification")]
    public partial class course_notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course_notification()
        {
            courses1 = new HashSet<courses>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string msg { get; set; }

        public int? course_courseID { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }

        public virtual courses courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<courses> courses1 { get; set; }
    }
}
