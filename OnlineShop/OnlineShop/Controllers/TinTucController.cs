using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index(int newsid)
        {
            var news = new TinTucDAL().GetID(newsid);

            
            return View(news);
            
        }
        public ActionResult All(int page = 1, int pageSize = 9)
        {
            int totalRecord = 0;
            var model = new TinTucDAL().GetAll(ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.AllNews = model;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);

        }
    }
}