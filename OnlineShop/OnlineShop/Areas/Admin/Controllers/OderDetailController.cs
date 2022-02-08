using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OderDetailController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new OrderDetailDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        //public ActionResult Insert()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Insert(oderdetail od)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dal = new OrderDetailDAL();
        //        od.TrangThai = true;
        //        var result = dal.Insert(od);
        //        if (result == true)
        //        {
        //            return RedirectToAction("Index", "OderDetail");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm mới không thành công");
        //        }
        //    }
        //    return View("Index");

        //}
        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(oderdetail od)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dal = new OrderDetailDAL();

        //        var result = dal.Update(od);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "OderDetail");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhật không thành công");
        //        }
        //    }
        //    return View("Index");
        //}
        [HttpDelete]
        public ActionResult Delete(long Id)
        {
            new OrderDetailDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}