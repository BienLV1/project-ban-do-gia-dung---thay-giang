using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class HangXsDAL
    {

        public OnlineShopContextDb db = null;
        public HangXsDAL()
        {
            db = new OnlineShopContextDb();
        }
        public hangsx GetByID(string MAHANGSX)
        {
            return db.hangsxes.SingleOrDefault(x => x.MAHANGSX == MAHANGSX);
        }
        public hangsx GetID(int id)
        {
            return db.hangsxes.SingleOrDefault(x => x.ID == id);
        }
        public List<hangsx> GetAll()
        {
            return db.hangsxes.Where(x => x.TrangThai == true).ToList();
        }
        public List<hangsx> GetAllTrangThai()
        {
            return db.hangsxes.ToList();
        }
        public bool Insert(hangsx entity)
        {
            var hsx = db.hangsxes.SingleOrDefault(x => x.MAHANGSX == entity.MAHANGSX);
            if (hsx == null)
            {
                db.hangsxes.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<hangsx> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<hangsx> model = db.hangsxes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MAHANGSX.Contains(searchString) || x.TENHANG.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.MAHANGSX).ToPagedList(page, pageSize);
        }
        public bool Update(hangsx entity)
        {
            try
            {
                var hsx = db.hangsxes.Find(entity.ID);
                hsx.MAHANGSX = entity.MAHANGSX;
                hsx.TENHANG = entity.TENHANG;
                hsx.ANH = entity.ANH;
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
                var hsx = db.hangsxes.Find(ID);
                db.hangsxes.Remove(hsx);
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
