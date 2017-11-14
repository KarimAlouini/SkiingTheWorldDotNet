using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaine.entities
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        public int userId { get; set; }

        [ForeignKey("userdId")]
        [Required]
        public virtual user user { get; set; }

        public IEnumerable<product> Products { get; set; }
    }
}
