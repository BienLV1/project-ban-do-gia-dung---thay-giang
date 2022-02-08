using Models.DAL;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 5)
        {
            var dal = new UserDAL();
            ViewBag.SearchString = searchString;
            var model = dal.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(User user)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDAL();
                user.TrangThai = true;
                user.Quyen = 1;
                var result = dal.Insert(user);
                if (result == true)
                {
                    return RedirectToAction("Index", "User");
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
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDAL();
                
                var result = dal.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
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
            new UserDAL().Delete(Id);
            return RedirectToAction("Index");
        }
    }
}