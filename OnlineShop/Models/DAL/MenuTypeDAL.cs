using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class MenuTypeDAL
    {
        public OnlineShopContextDb db = null;
        public MenuTypeDAL()
        {
            db = new OnlineShopContextDb();
        }
        public MenuType GetByID(string Name)
        {
            return db.MenuTypes.SingleOrDefault(x => x.Name == Name);
        }
        public MenuType GetID(long id)
        {
            return db.MenuTypes.SingleOrDefault(x => x.ID == id);
        }
        public List<MenuType> GetAll()
        {
            return db.MenuTypes.ToList();
        }

        public bool Insert(MenuType entity)
        {
            var mt = db.MenuTypes.SingleOrDefault(x => x.Name == entity.Name);
            if (mt == null)
            {
                db.MenuTypes.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<MenuType> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MenuType> model = db.MenuTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool Update(MenuType entity)
        {
            try
            {
                var mt = db.MenuTypes.Find(entity.ID);
                mt.ID = entity.ID;
                mt.Name = entity.Name;
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
                var mt = db.MenuTypes.Find(ID);
                db.MenuTypes.Remove(mt);
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
