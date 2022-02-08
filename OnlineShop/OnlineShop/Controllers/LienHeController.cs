using Models.DAL;
using Models.FrameWork;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(khachhang kh)
        {
            if (ModelState.IsValid)
            {
                var dal = new KhachHangDAL();
                kh.TrangThai = true;
                var result = dal.Insert(kh);
                if (result == true)
                {
                    return RedirectToAction("Index", "LienHe");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View("Index");
        }
    }
}