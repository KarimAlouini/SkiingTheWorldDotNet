namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.access_tokens")]
    public partial class access_tokens
    {
        public int id { get; set; }

        public DateTime? expiresAt { get; set; }

        [StringLength(255)]
        public string value { get; set; }

        public int user_id { get; set; }

        public virtual user user { get; set; }
    }
}
