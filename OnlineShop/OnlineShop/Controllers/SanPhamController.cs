using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Detail(int productId)
        {

            var product = new SanPhamDAL().GetByID(productId);

            ViewBag.SanPhamTuongTu = new SanPhamDAL().ListProductCategoryId(productId);
            return View(product);

        }
        [HttpGet]
        public ActionResult AllProduct( int page = 1, int pageSize = 6)
        {
            var product = new SanPhamDAL();
            int totalRecord = 0;
            var model = new SanPhamDAL().GetAll(ref totalRecord, page, pageSize);
            
            ViewBag.AllCategory = new LoaiSpDAL().GetAll();
            ViewBag.AllHangSx = new HangXsDAL().GetAll();
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.AllProduct = model;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult ProductCategoryId(int category, int page = 1, int pageSize = 6)
        {
            int totalRecord = 0;
            ViewBag.Category = new LoaiSpDAL().GetByID(category);
            ViewBag.AllCategory = new LoaiSpDAL().GetAll();
            ViewBag.AllHangSx = new HangXsDAL().GetAll();
            var model = new SanPhamDAL().ListProductCategory(category,ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.productCategory = model;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult HangSxId(int HangSx, int page = 1, int pageSize = 6)
        {
            ViewBag.AllCategory = new LoaiSpDAL().GetAll();
            ViewBag.AllHangSx = new HangXsDAL().GetAll();
            ViewBag.HangSx = new HangXsDAL().GetID(HangSx);
            int totalRecord = 0;
            var model = new SanPhamDAL().ListProductHangSx(HangSx, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.productHangSx = model;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        
        
    }
}