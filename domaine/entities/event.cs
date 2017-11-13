namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class _event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public _event()
        {
            event_invitation = new HashSet<event_invitation>();
            user_event = new HashSet<user_event>();
            user_event1 = new HashSet<user_event>();
            keyword = new HashSet<keyword>();
            keyword1 = new HashSet<keyword>();
            user2 = new HashSet<user>();
        }

        public int id { get; set; }

        public DateTime? End { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        public double? latidue { get; set; }

        public double? longitude { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        public int? zipCode { get; set; }

        public DateTime Start { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? maxPlace { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int? statue { get; set; }

        public int user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<event_invitation> event_invitation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_event> user_event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_event> user_event1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<keyword> keyword { get; set; }

        public virtual user user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<keyword> keyword1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user2 { get; set; }
    }
}
