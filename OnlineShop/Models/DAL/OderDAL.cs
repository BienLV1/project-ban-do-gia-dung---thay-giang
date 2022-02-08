using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class OderDAL
    {
        public OnlineShopContextDb db = null;
        public OderDAL()
        {
            db = new OnlineShopContextDb();
        }
        public oder GetByID(string name)
        {
            return db.oders.SingleOrDefault(x => x.name == name);
        }
        public oder GetID(long id)
        {
            return db.oders.SingleOrDefault(x => x.ID == id);
        }
        public List<oder> GetAll()
        {
            return db.oders.Where(x => x.TrangThai == true).ToList();
        }
        public List<oder> GetAllTrangThai()
        {
            return db.oders.ToList();
        }
        public long Insert(oder entity)
        {
            db.oders.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }

        public IEnumerable<oder> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<oder> model = db.oders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.name).ToPagedList(page, pageSize);
        }
        public bool Update(oder entity)
        {
            try
            {
                var od = db.oders.Find(entity.ID);
                od.name = entity.name;
                od.phone = entity.phone;
                od.address = entity.address;
                od.email = entity.email;
                od.total = entity.total;
                od.ngaydathang = entity.ngaydathang;
                od.thanhtoan = entity.thanhtoan;
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
                var od = db.oders.Find(ID);
                db.oders.Remove(od);
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
