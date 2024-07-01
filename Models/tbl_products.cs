using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecom_Food_Cart.Models
{
    public class tbl_products
    {
        public int productId { get; set; }

        public int categoryId { get; set; }

        public string category_Name { get; set; }

        public string product_Name { get; set; }

        public decimal price { get; set;}

        public int quantity { get; set; }

        public string description { get; set;}

    }
}