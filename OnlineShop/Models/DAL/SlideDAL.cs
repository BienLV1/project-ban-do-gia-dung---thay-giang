using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class SlideDAL
    {
        public OnlineShopContextDb db = null;
        public SlideDAL()
        {
            db = new OnlineShopContextDb();
        }
        
        public Slide GetID(long id)
        {
            return db.Slides.SingleOrDefault(x => x.ID == id);
        }
        public List<Slide> GetAll()
        {
            return db.Slides.Where(x => x.Status == true).ToList();
        }
        public List<Slide> GetAllTrangThai()
        {
            return db.Slides.ToList();
        }
        public bool Insert(Slide entity)
        {
            var bl = db.Slides.SingleOrDefault(x => x.Image == entity.Image);
            if (bl == null)
            {
                db.Slides.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Image.Contains(searchString));
            }
            return model.Where(x => x.Status == true).OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool Update(Slide entity)
        {
            try
            {
                var sl = db.Slides.Find(entity.ID);
                sl.Image = entity.Image;
                
                sl.CreateDate = entity.CreateDate;
                
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
                var sl = db.Slides.Find(ID);
                db.Slides.Remove(sl);
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
