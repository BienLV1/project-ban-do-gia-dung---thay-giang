using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class LoaiSpDAL
    {
        public OnlineShopContextDb db = null;
        public LoaiSpDAL()
        {
            db = new OnlineShopContextDb();
        }
        public loaisp GetByID(int category)
        {
            return db.loaisps.SingleOrDefault(x => x.ID == category);
        }
        public loaisp GetID(long id)
        {
            return db.loaisps.SingleOrDefault(x => x.ID == id);
        }
        public List<loaisp> GetAll()
        {
            return db.loaisps.Where(x => x.TrangThai == true).ToList();
        }
        public List<loaisp> GetAllTrangThai()
        {
            return db.loaisps.ToList();
        }
        public bool Insert(loaisp entity)
        {
            var loai = db.loaisps.SingleOrDefault(x => x.MALOAI == entity.MALOAI);
            if (loai == null)
            {
                db.loaisps.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<loaisp> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<loaisp> model = db.loaisps;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MALOAI.Contains(searchString) || x.TENLOAI.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.MALOAI).ToPagedList(page, pageSize);
        }
        public bool Update(loaisp entity)
        {
            try
            {
                var loai = db.loaisps.Find(entity.ID);
                loai.MALOAI = entity.MALOAI;
                loai.TENLOAI = entity.TENLOAI;
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
                var loai = db.loaisps.Find(ID);
                db.loaisps.Remove(loai);
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
