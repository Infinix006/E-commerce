//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecom_Food_Cart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_customer()
        {
            this.tbl_order = new HashSet<tbl_order>();
        }
    
        public int customerId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string mob_number { get; set; }
        public string email { get; set; }
        public string account_Password { get; set; }
        public string order_Note { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_order> tbl_order { get; set; }
    }
}