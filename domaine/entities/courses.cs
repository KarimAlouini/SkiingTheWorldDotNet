namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public courses()
        {
            course_notification = new HashSet<course_notification>();
            courseparticipation = new HashSet<courseparticipation>();
            coursereview = new HashSet<coursereview>();
        }

        [Key]
        public int courseID { get; set; }

        [StringLength(255)]
        public string courseLevel { get; set; }

        [StringLength(255)]
        public string courseName { get; set; }

        [StringLength(255)]
        public string courseState { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        public int maxParticipants { get; set; }

        public double? price { get; set; }

        public int? guide_id { get; set; }

        public int? notification_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_notification> course_notification { get; set; }

        public virtual course_notification course_notification1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<courseparticipation> courseparticipation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coursereview> coursereview { get; set; }

        public virtual user user { get; set; }
    }
}
