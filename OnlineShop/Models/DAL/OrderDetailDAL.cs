using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class OrderDetailDAL
    {
        public OnlineShopContextDb db = null;
        public OrderDetailDAL()
        {
            db = new OnlineShopContextDb();
        }
        public oderdetail GetByID(string hoten)
        {
            return db.oderdetails.SingleOrDefault(x => x.hoten == hoten);
        }
        public oderdetail GetID(long id)
        {
            return db.oderdetails.SingleOrDefault(x => x.ID == id);
        }
        public List<oderdetail> GetAll()
        {
            return db.oderdetails.Where(x => x.TrangThai == true).ToList();
        }
        public List<oderdetail> GetAllTrangThai()
        {
            return db.oderdetails.ToList();
        }
        public bool Insert(oderdetail detail)
        {
            try
            {
                db.oderdetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public IEnumerable<oderdetail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<oderdetail> model = db.oderdetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.hoten.Contains(searchString) || x.tensp.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.hoten).ToPagedList(page, pageSize);
        }
        public bool Update(oderdetail entity)
        {
            try
            {
                var od = db.oderdetails.Find(entity.ID);
                od.hoten = entity.hoten;
                od.masp = entity.masp;
                od.tensp = entity.tensp;
                od.soluong = entity.soluong;
                od.giatien = entity.giatien;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(long ID)
        {
            try
            {
                var od = db.oderdetails.Find(ID);
                db.oderdetails.Remove(od);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
