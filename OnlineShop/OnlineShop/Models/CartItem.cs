using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CartItem
    {
        public sanpham Product { set; get; }
        public int Quantity { set; get; }
        public int Ship { set; get; }
    }
}