using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TProduct
    {
        public TProduct()
        {
            TShoppingCarts = new HashSet<TShoppingCart>();
        }

        public int FId { get; set; }

        //[DisplayName("產品名稱")]
        public string FName { get; set; }
        //[DisplayName("成本")]
        public decimal? FCost { get; set; }

        //[DisplayName("庫存量")]
        public int? FQty { get; set; }

        //[DisplayName("售價")]
        public decimal? FPrice { get; set; }
        //[DisplayName("產品圖")]
        public string FImagePath { get; set; }

        public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; }
    }
}
