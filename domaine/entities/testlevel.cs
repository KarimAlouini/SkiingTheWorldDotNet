namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.testlevel")]
    public partial class testlevel
    {
        [Key]
        public int idTest { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int score { get; set; }

        public int? test_idTest { get; set; }

        public int? user_id { get; set; }

        public virtual test test { get; set; }

        public virtual user user { get; set; }
    }
}
