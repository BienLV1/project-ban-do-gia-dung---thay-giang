using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class MenuDAL
    {
        public OnlineShopContextDb db = null;
        public MenuDAL()
        {
            db = new OnlineShopContextDb();
        }
        public Menu GetByID(long id)
        {
            return db.Menus.Find(id);
        }
        public Menu GetID(long id)
        {
            return db.Menus.SingleOrDefault(x => x.ID == id);
        }
        public List<Menu> GetAll()
        {
            return db.Menus.Where(x => x.Status == true).ToList();
        }
        public List<Menu> GetAllTrangThai()
        {
            return db.Menus.ToList();
        }

        public bool Insert(Menu entity)
        {
            var sp = db.Menus.SingleOrDefault(x => x.Text == entity.Text);
            if (sp == null)
            {
                db.Menus.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString));
            }
            return model.Where(x => x.Status == true).OrderBy(x => x.Text).ToPagedList(page, pageSize);
        }
        public bool Update(Menu entity)
        {
            try
            {
                var mn = db.Menus.Find(entity.ID);
                mn.Text = entity.Text;
                mn.Link = entity.Link;
                
                mn.TypeID = entity.TypeID;
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
                var tt = db.Menus.Find(ID);
                db.Menus.Remove(tt);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Menu> ListByGroupID(long id)
        {
            return db.Menus.Where(x => x.TypeID == id && x.Status == true).OrderByDescending(x => x.Text).ToList();
        }
    }
}
