using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class TinTucDAL
    {
        public OnlineShopContextDb db = null;
        public TinTucDAL()
        {
            db = new OnlineShopContextDb();
        }
        public tintuc GetByID(string MATIN)
        {
            return db.tintucs.SingleOrDefault(x => x.MATIN == MATIN);
        }
        public tintuc GetID(long id)
        {
            return db.tintucs.SingleOrDefault(x => x.ID == id);
        }
        public List<tintuc> GetAll(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.tintucs.Where(x => x.TrangThai == true).Count();
            var model = db.tintucs.Where(x => x.TrangThai == true).OrderByDescending(x => x.NGAYDANG).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<tintuc> ListNews(int top)
        {
            return db.tintucs.Where(x => x.TrangThai == true).Take(top).ToList();
        }
        public List<tintuc> GetAllTrangThai()
        {
            return db.tintucs.ToList();
        }
        public bool Insert(tintuc entity)
        {
            var tt = db.tintucs.SingleOrDefault(x => x.MATIN == entity.MATIN);
            if (tt == null)
            {
                db.tintucs.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<tintuc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<tintuc> model = db.tintucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MATIN.Contains(searchString) || x.TIEUDE.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.MATIN).ToPagedList(page, pageSize);
        }
        public bool Update(tintuc entity)
        {
            try
            {
                var tt = db.tintucs.Find(entity.ID);
                tt.MATIN = entity.MATIN;
                tt.TIEUDE = entity.TIEUDE;
                tt.ANH = entity.ANH;
                tt.NOIDUNG = entity.NOIDUNG;
                tt.NGAYDANG = entity.NGAYDANG;
                tt.NDNGAN = entity.NDNGAN;
                tt.LOAITIN = entity.LOAITIN;
                
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
                var tt = db.tintucs.Find(ID);
                db.tintucs.Remove(tt);
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
