using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new SlideDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(Slide sl)
        {
            if (ModelState.IsValid)
            {
                var dal = new SlideDAL();
                sl.Status = true;
                sl.CreateDate = DateTime.Now;
                var result = dal.Insert(sl);
                if (result == true)
                {
                    return RedirectToAction("Index", "Slide");
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
        public ActionResult Edit(Slide sl)
        {
            if (ModelState.IsValid)
            {
                var dal = new SlideDAL();

                var result = dal.Update(sl);
                if (result)
                {
                    return RedirectToAction("Index", "Slide");
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
            new SlideDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}