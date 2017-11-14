namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class access_tokens
    {
        public int id { get; set; }

        public DateTime? expiresAt { get; set; }

        [StringLength(255)]
        public string value { get; set; }
        
        public int userId{ get; set; }
        [ForeignKey("userId")]
        public virtual user user { get; set; }
    }
}
