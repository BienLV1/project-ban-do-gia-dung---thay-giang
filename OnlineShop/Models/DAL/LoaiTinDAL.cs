using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class LoaiTinDAL
    {
        public OnlineShopContextDb db = null;
        public LoaiTinDAL()
        {
            db = new OnlineShopContextDb();
        }
        public loaitintuc GetByID(string LOAITIN)
        {
            return db.loaitintucs.SingleOrDefault(x => x.LOAITIN == LOAITIN);
        }
        public loaitintuc GetID(long id)
        {
            return db.loaitintucs.SingleOrDefault(x => x.ID == id);
        }
        public List<loaitintuc> GetAll()
        {
            return db.loaitintucs.ToList();
        }
        
        public bool Insert(loaitintuc entity)
        {
            var ltt = db.loaitintucs.SingleOrDefault(x => x.LOAITIN == entity.LOAITIN);
            if (ltt == null)
            {
                db.loaitintucs.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<loaitintuc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<loaitintuc> model = db.loaitintucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.LOAITIN.Contains(searchString) || x.TENLOAITIN.Contains(searchString));
            }
            return model.OrderBy(x => x.LOAITIN).ToPagedList(page, pageSize);
        }
        public bool Update(loaitintuc entity)
        {
            try
            {
                var ltt = db.loaitintucs.Find(entity.ID);
                ltt.LOAITIN = entity.LOAITIN;
                ltt.TENLOAITIN = entity.TENLOAITIN;
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
                var ltt = db.loaitintucs.Find(ID);
                db.loaitintucs.Remove(ltt);
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
