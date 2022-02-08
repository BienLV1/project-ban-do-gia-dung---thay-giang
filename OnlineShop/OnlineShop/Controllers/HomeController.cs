using Models.DAL;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            ViewBag.Slide = new SlideDAL().GetAll();
            var product = new SanPhamDAL();
            ViewBag.NewProduct = product.ListNewProduct(4);
            ViewBag.FeattureProduct = product.ListFeatureProduct(4);
            ViewBag.SaleProduct = product.ListSaleProduct(3);
            ViewBag.TenLoaiSp = new LoaiSpDAL().GetAll();
            ViewBag.AllProduct = product.GetAll(ref totalRecord, page, pageSize);
            ViewBag.ListTinTuc = new TinTucDAL().ListNews(3);
            ViewBag.ListFeedBack = new BinhLuanDAL().ListFBNew(3);
            ViewBag.Logo = new HangXsDAL().GetAll();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAL().ListByGroupID(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDAL().ListByGroupID(2);
            return PartialView(model);
        }
       
    }
}