using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class AddCouponModel
    {
        [Key]
        public int Id;
        public int  Count { get; set; }
        public double Amount { get; set; }
    }
}