using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OderController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new OderDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        //public ActionResult Insert()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Insert(oder od)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dal = new OderDAL();
        //        od.TrangThai = true;
        //        var result = dal.Insert(od);
        //        if (result == true)
        //        {
        //            return RedirectToAction("Index", "Oder");
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
        //public ActionResult Edit(oder od)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dal = new OderDAL();

        //        var result = dal.Update(od);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "Oder");
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
            new OderDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}