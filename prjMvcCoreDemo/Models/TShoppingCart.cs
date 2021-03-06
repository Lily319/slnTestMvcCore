using System;
using System.Collections.Generic;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TShoppingCart
    {
        public int FId { get; set; }
        public string FDate { get; set; }
        public int? FCustomerId { get; set; }
        public int? FProductId { get; set; }
        public int? FCount { get; set; }
        public decimal? FPrice { get; set; }

        public virtual TCustomer FCustomer { get; set; }
        public virtual TProduct FProduct { get; set; }
    }
}
