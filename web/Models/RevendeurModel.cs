using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class RevendeurModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please specify a name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Please specify a phone number")]
        [Display(Name ="Phone number")]
        [StringLength(13,ErrorMessage ="Please input a valid phone number")]
        public string tel { get; set; }
        [Required(ErrorMessage ="Please input coordinates")]
        public float Longitude { get; set; }
        [Required(ErrorMessage = "Please input coordinates")]
        public float Latitude { get; set; }
        [Required(ErrorMessage ="Please input an email address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please specify a valid email address")]
        public String Email { get; set; }
    }
}