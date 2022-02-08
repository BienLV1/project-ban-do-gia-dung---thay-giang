using System;
using Models.DAL;
using Models.FrameWork;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 5)
        {
            var dal = new KhachHangDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(khachhang kh)
        {
            if (ModelState.IsValid)
            {
                var dal = new KhachHangDAL();
                kh.TrangThai = true;
                var result = dal.Insert(kh);
                if (result == true)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View("Index");

        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(khachhang kh)
        {
            if (ModelState.IsValid)
            {
                var dal = new KhachHangDAL();

                var result = dal.Update(kh);
                if (result)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long Id)
        {
            new KhachHangDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}