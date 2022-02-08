using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 1)
        {
            var dal = new TinTucDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(tintuc tt)
        {
            if (ModelState.IsValid)
            {
                var dal = new TinTucDAL();
                tt.TrangThai = true;
                tt.NGAYDANG = DateTime.Now;
                var result = dal.Insert(tt);
                if (result == true)
                {
                    return RedirectToAction("Index", "TinTuc");
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
        public ActionResult Edit(tintuc tt)
        {
            if (ModelState.IsValid)
            {
                var dal = new TinTucDAL();

                var result = dal.Update(tt);
                if (result)
                {
                    return RedirectToAction("Index", "TinTuc");
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
            new TinTucDAL().Delete(Id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dal = new LoaiTinDAL();
            ViewBag.LOAITIN = new SelectList(dal.GetAll(), "LOAITIN", "TENLOAITIN", selectedId);
            
        }
    }
}