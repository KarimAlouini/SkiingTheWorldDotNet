namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.seller")]
    public partial class seller
    {
        public int id { get; set; }

        public double? latidue { get; set; }

        public double? longitude { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }
    }
}
