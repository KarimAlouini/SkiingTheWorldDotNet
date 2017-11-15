namespace SkiingTheWorld_PI.Domaine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class souscategorie
    {
        public enum CategorieEnum
        {
            Adult,
            Children,
            Article
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Libelle { get; set; }

        public CategorieEnum MarquecategorieProd { get; set; }

    }
}
