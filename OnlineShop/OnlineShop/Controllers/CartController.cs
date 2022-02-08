using Models.DAL;
using Models.FrameWork;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstant.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new SanPhamDAL().GetByID(productId);
            var cart = Session[CommonConstant.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    item.Ship = 30000;
                    list.Add(item);
                }
                //Gán vào session
                Session[CommonConstant.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CommonConstant.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var cart = (List<CartItem>)Session[CommonConstant.CartSession];
            var order = new oder();
            order.ngaydathang = DateTime.Now;
            order.address = address;
            order.phone = mobile;
            order.name = shipName;
            order.email = email;
            order.total = cart.Sum(x => x.Product.GIAMGIA.GetValueOrDefault(0) * x.Quantity);
            order.thanhtoan = "COD";
            order.TrangThai = true;
            try
            {
                var id = new OderDAL().Insert(order);
                
                var detailDao = new OrderDetailDAL();
                int total = 0;
                foreach (var item in cart)
                {
                    total += (item.Product.GIAMGIA.GetValueOrDefault(0) * item.Quantity);
                    var orderDetail = new oderdetail();
                    orderDetail.masp = item.Product.MASP;
                    orderDetail.ID = id;
                    orderDetail.giatien = total;
                    orderDetail.soluong = item.Quantity;
                    orderDetail.hoten = order.name;
                    orderDetail.tensp = item.Product.TENSP;
                    orderDetail.TrangThai = true;
                    detailDao.Insert(orderDetail);

                    
                }
                
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}