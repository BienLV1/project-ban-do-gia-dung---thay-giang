using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoaiTinController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new LoaiTinDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(loaitintuc ltt)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiTinDAL();
                
                var result = dal.Insert(ltt);
                if (result == true)
                {
                    return RedirectToAction("Index", "LoaiTin");
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
        public ActionResult Edit(loaitintuc ltt)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiTinDAL();

                var result = dal.Update(ltt);
                if (result)
                {
                    return RedirectToAction("Index", "LoaiTin");
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
            new LoaiTinDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}