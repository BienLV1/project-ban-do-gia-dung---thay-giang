using Models.DAL;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDAL();
                var result = dal.Login(model.UserName, Encryptor.GetHash(model.PassWord));
                if (result == 1)
                {
                    var user = dal.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.Quyen = user.Quyen;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    if (userSession.Quyen == 1)
                    {
                        return RedirectToAction("Index", "Homes");
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
            }
            return View("Index");
        }
    }
}