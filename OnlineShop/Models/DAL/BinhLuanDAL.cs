using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class BinhLuanDAL
    {
        public OnlineShopContextDb db = null;
        public BinhLuanDAL()
        {
            db = new OnlineShopContextDb();
        }
        public binhluan GetByID(string Email)
        {
            return db.binhluans.SingleOrDefault(x => x.EMAIL == Email);
        }
        public binhluan GetID(long id)
        {
            return db.binhluans.SingleOrDefault(x => x.ID == id);
        }
        public List<binhluan> GetAll()
        {
            return db.binhluans.Where(x => x.TrangThai == true).ToList();
        }
        public List<binhluan> GetAllTrangThai()
        {
            return db.binhluans.ToList();
        }
        public List<binhluan> ListFBNew(int top)
        {
            return db.binhluans.Where(x => x.TrangThai == true).OrderByDescending(y=>y.NGAYDANG).Take(top).ToList();
        }
        public bool Insert(binhluan entity)
        {
            var bl = db.binhluans.SingleOrDefault(x => x.EMAIL == entity.EMAIL);
            if (bl == null)
            {
                db.binhluans.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<binhluan> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<binhluan> model = db.binhluans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.EMAIL.Contains(searchString) || x.SDT.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.NGAYDANG).ToPagedList(page, pageSize);
        }
        public bool Update(binhluan entity)
        {
            try
            {
                var bl = db.binhluans.Find(entity.ID);
                bl.NDBL = entity.NDBL;
                bl.EMAIL = entity.EMAIL;
                bl.NGAYDANG = entity.NGAYDANG;
                bl.SDT = entity.SDT;
                bl.ANH = entity.ANH;
                bl.TENKH = entity.TENKH;
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
                var bl = db.binhluans.Find(ID);
                db.binhluans.Remove(bl);
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
