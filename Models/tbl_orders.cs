using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecom_Food_Cart.Models
{
    public class tbl_orders
    { 
        public int orderId { get; set; }

        public string customer { get; set; }

        public string product_Name { get; set; }

        public string status { get; set; }

        public decimal order_total { get; set; }

        public string order_date { get; set; }
    }
}