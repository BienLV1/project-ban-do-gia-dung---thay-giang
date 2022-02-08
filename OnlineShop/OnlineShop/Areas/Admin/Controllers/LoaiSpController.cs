using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoaiSpController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dal = new LoaiSpDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(loaisp loai)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiSpDAL();
                loai.TrangThai = true;
                var result = dal.Insert(loai);
                if (result == true)
                {
                    return RedirectToAction("Index", "LoaiSp");
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
        public ActionResult Edit(loaisp loai)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiSpDAL();

                var result = dal.Update(loai);
                if (result)
                {
                    return RedirectToAction("Index", "LoaiSp");
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
            new LoaiSpDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}