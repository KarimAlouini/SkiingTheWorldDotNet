using SkiingTheWorld_PI.Domaine.Entities;

namespace domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {

       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reference { get; set; }
        

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Marque { get; set; }

        [StringLength(255)]
        public string Modele { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Photo { get; set; }

        public int Quantity { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
        public double price { get; set; }




        public int sousCategorieProdId { get; set; }


        [ForeignKey("sousCategorieProdId")]
        public virtual souscategorie sousCategorieProd { get; set; }


        public int userId { get; set; }

        public override bool Equals(object obj)
        {
            product other = (product) obj;
            return other.Reference == this.Reference;
        }
    }
}
