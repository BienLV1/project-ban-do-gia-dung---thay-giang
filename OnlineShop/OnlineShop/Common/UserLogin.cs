using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    public class UserLogin
    {
        public string UserName { set; get; }
        public long UserID { set; get; }
        public int? Quyen { get; set; }
    }
}