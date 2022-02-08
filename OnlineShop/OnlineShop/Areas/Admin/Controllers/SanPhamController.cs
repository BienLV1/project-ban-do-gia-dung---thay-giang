using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 1)
        {
            var dal = new SanPhamDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }


        [HttpGet]
        public ActionResult Insert()
        {
            SetViewBag();
            
            return View();
        }

        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult Insert(sanpham sp)
        {
            if (ModelState.IsValid)
            {
                var dal = new SanPhamDAL();
                sp.TrangThai = true;
                sp.NGAYNHAP = DateTime.Now;
                var result = dal.Insert(sp);
                if (result == true)
                {
                    return RedirectToAction("Index", "SanPham");
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
        public ActionResult Edit(sanpham sp)
        {
            if (ModelState.IsValid)
            {
                var dal = new SanPhamDAL();

                var result = dal.Update(sp);
                if (result)
                {
                    return RedirectToAction("Index", "SanPham");
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
            new SanPhamDAL().Delete(Id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long ?selectedId=null)
        {
            var dal = new HangXsDAL();
            ViewBag.MAHANGSX = new SelectList(dal.GetAll(), "ID", "TENHANG", selectedId);
            var dal_loai = new LoaiSpDAL();
            ViewBag.MALOAI = new SelectList(dal_loai.GetAll(), "ID", "TENLOAI", selectedId);
        }
        
    }
}