using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new MenuDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Menu mn)
        {
            if (ModelState.IsValid)
            {
                var dal = new MenuDAL();
                mn.Status = true;
                var result = dal.Insert(mn);
                if (result == true)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            SetViewBag();
            return View("Index");

        }
        [HttpGet]
        public ActionResult Edit()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                var dal = new MenuDAL();

                var result = dal.Update(mn);
                if (result)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long Id)
        {
            new MenuDAL().Delete(Id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dal = new MenuTypeDAL();
            ViewBag.TypeID = new SelectList(dal.GetAll(), "ID", "Name", selectedId);
            
        }
    }
}