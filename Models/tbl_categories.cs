using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecom_Food_Cart.Models
{
    public class tbl_categories
    {
        public int categoryId { get; set; }

        [Required]
        public string category_Name { get; set; }

        [Required]
        public int sort_Order { get; set;}
    }
}