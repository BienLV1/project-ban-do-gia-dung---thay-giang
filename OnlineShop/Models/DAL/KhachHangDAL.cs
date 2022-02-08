using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class KhachHangDAL
    {
        public OnlineShopContextDb db = null;
        public KhachHangDAL()
        {
            db = new OnlineShopContextDb();
        }
        public khachhang GetByID(string Email)
        {
            return db.khachhangs.SingleOrDefault(x => x.EMAIL == Email);
        }
        public khachhang GetID(long id)
        {
            return db.khachhangs.SingleOrDefault(x => x.ID == id);
        }
        public List<khachhang> GetAll()
        {
            return db.khachhangs.Where(x => x.TrangThai == true).ToList();
        }
        public List<khachhang> GetAllTrangThai()
        {
            return db.khachhangs.ToList();
        }
        public bool Insert(khachhang entity)
        {
            var kh = db.khachhangs.SingleOrDefault(x => x.EMAIL == entity.EMAIL);
            if (kh == null)
            {
                db.khachhangs.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<khachhang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<khachhang> model = db.khachhangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENKH.Contains(searchString) || x.EMAIL.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.TENKH).ToPagedList(page, pageSize);
        }
        public bool Update(khachhang entity)
        {
            try
            {
                var kh = db.khachhangs.Find(entity.ID);
                kh.TENKH = entity.TENKH;
                kh.EMAIL = entity.EMAIL;
                kh.SDT = entity.SDT;
                kh.ND = kh.ND;
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
                var kh = db.khachhangs.Find(ID);
                db.khachhangs.Remove(kh);
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
