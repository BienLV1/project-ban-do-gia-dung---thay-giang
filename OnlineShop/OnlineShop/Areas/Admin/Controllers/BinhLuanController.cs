using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BinhLuanController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 1)
        {
            var dal = new BinhLuanDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(binhluan bl)
        {
            if (ModelState.IsValid)
            {
                var dal = new BinhLuanDAL();
                bl.TrangThai = true;
                bl.NGAYDANG = DateTime.Now;
                var result = dal.Insert(bl);
                if (result == true)
                {
                    return RedirectToAction("Index", "BinhLuan");
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
        public ActionResult Edit(binhluan bl)
        {
            if (ModelState.IsValid)
            {
                var dal = new BinhLuanDAL();

                var result = dal.Update(bl);
                if (result)
                {
                    return RedirectToAction("Index", "BinhLuan");
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
            new BinhLuanDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}