using Models.FrameWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class UserDAL
    {
        public OnlineShopContextDb db = null;
        public UserDAL()
        {
            db = new OnlineShopContextDb();
        }
        public User GetByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User GetByID(long id)
        {
            return db.Users.SingleOrDefault(x => x.ID == id);
        }
        public List<User> GetAll()
        {
            return db.Users.Where(x => x.TrangThai == true).ToList();
        }
        public List<User> GetAllTrangThai()
        {
            return db.Users.ToList();
        }
        public bool Insert(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault
                (model => model.UserName == userName);
            if (result == null)
            {
                return -1;
            }
            else if (result.TrangThai == false)
            {
                return -2;
            }
            else if (result.PassWord != password)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public IEnumerable<User> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.UserName).ToPagedList(page, pageSize);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Phone = entity.Phone;
                user.Email = entity.Email;
                user.Quyen = entity.Quyen;
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
                var user = db.Users.Find(ID);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
