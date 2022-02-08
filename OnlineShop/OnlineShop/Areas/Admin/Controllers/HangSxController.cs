using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HangSxController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 5)
        {
            var dal = new HangXsDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(hangsx hsx)
        {
            if (ModelState.IsValid)
            {
                var dal = new HangXsDAL();
                hsx.TrangThai = true;
                var result = dal.Insert(hsx);
                if (result == true)
                {
                    return RedirectToAction("Index", "HangSx");
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
        public ActionResult Edit(hangsx hsx)
        {
            if (ModelState.IsValid)
            {
                var dal = new HangXsDAL();

                var result = dal.Update(hsx);
                if (result)
                {
                    return RedirectToAction("Index", "HangSx");
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
            new HangXsDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}