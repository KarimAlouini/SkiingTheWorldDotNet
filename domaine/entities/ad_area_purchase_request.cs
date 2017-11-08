namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skiworld.ad_area_purchase_request")]
    public partial class ad_area_purchase_request
    {
        public int id { get; set; }

        public int? confirmation { get; set; }

        public DateTime end_date { get; set; }

        public DateTime? startDate { get; set; }

        public int? adArea_id { get; set; }

        public int? user_id { get; set; }

        public virtual ad_area ad_area { get; set; }

        public virtual user user { get; set; }
    }
}
