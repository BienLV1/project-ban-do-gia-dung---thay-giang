using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new MenuTypeDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(MenuType mnt)
        {
            if (ModelState.IsValid)
            {
                var dal = new MenuTypeDAL();

                var result = dal.Insert(mnt);
                if (result == true)
                {
                    return RedirectToAction("Index", "MenuType");
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
        public ActionResult Edit(MenuType mnt)
        {
            if (ModelState.IsValid)
            {
                var dal = new MenuTypeDAL();

                var result = dal.Update(mnt);
                if (result)
                {
                    return RedirectToAction("Index", "MenuType");
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
            new MenuTypeDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}