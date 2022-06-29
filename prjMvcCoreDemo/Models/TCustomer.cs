using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TCustomer
    {
        public TCustomer()
        {
            TShoppingCarts = new HashSet<TShoppingCart>();
        }

        public int FId { get; set; }
        [DisplayName("姓名")]
        public string FName { get; set; }
        [DisplayName("電話")]
        public string FPhone { get; set; }
        [DisplayName("Email")]
        public string FEmail { get; set; }
        [DisplayName("地址")]
        public string FAddress { get; set; }
        [DisplayName("密碼")]
        public string FPassword { get; set; }

        public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; }
    }
}
