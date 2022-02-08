using Models.FrameWork;

using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class SanPhamDAL
    {
        public OnlineShopContextDb db = null;
        public SanPhamDAL()
        {
            db = new OnlineShopContextDb();
        }
        
        
        public sanpham GetByID(int productId)
        {
            return db.sanphams.Find(productId);
        }
        public List<string> ListName(string keyword)
        {
            return db.sanphams.Where(x => x.TENSP.Contains(keyword)).Select(x => x.TENSP).ToList();
        }
        public sanpham GetID(long id)
        {
            return db.sanphams.SingleOrDefault(x => x.ID == id);
        }
        public List<sanpham> ListProductCategory( int category, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            
            var product = db.loaisps.Find(category);
            totalRecord = db.sanphams.Where(x => x.TrangThai == true && x.MALOAI == product.ID).Count();
            var model = db.sanphams.Where(x => x.TrangThai == true && x.MALOAI == product.ID).OrderByDescending(x => x.NGAYNHAP).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<sanpham> ListProductHangSx(int HangSx, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            var product = db.hangsxes.Find(HangSx);
            totalRecord = db.sanphams.Where(x => x.TrangThai == true && x.MAHANGSX == product.ID).Count();
            var model = db.sanphams.Where(x => x.TrangThai == true && x.MAHANGSX == product.ID).OrderByDescending(x => x.NGAYNHAP).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<sanpham> ListProductCategoryId(int productId)
        {
            var product = db.sanphams.Find(productId);
            return db.sanphams.Where(x => x.TrangThai == true && x.ID != productId && x.MALOAI == product.MALOAI).ToList();
        }
        public List<sanpham> GetAll(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            
            totalRecord = db.sanphams.Where(x => x.TrangThai == true).Count();
            var model = db.sanphams.Where(x => x.TrangThai == true).OrderByDescending(x => x.NGAYNHAP).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<sanpham> GetAllTrangThai()
        {
            return db.sanphams.ToList();
        }

        public List<sanpham> ListNewProduct(int top)
        {
            return db.sanphams.Where(x => x.TrangThai == true).OrderByDescending(y=>y.NGAYNHAP).Take(top).ToList();
        }
        public List<sanpham> ListFeatureProduct(int top)
        {
            return db.sanphams.Where(x => x.TrangThai == true && x.TOPHOT!=null && x.TOPHOT>DateTime.Now).OrderByDescending(y => y.TOPHOT).Take(top).ToList();
        }
        public List<sanpham> ListSaleProduct(int top)
        {
            
            return db.sanphams.Where(x => x.TrangThai == true && x.GIAMGIA !=null ).OrderByDescending(y => y.NGAYNHAP).Take(top).ToList();
        }
        public bool Insert(sanpham entity)
        {
            var sp = db.sanphams.SingleOrDefault(x => x.MASP == entity.MASP);
            if (sp == null)
            {
                db.sanphams.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<sanpham> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<sanpham> model = db.sanphams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MASP.Contains(searchString) || x.TENSP.Contains(searchString));
            }
            return model.Where(x => x.TrangThai == true).OrderBy(x => x.MASP).ToPagedList(page, pageSize);
        }
        public bool Update(sanpham entity)
        {
            try
            {
                var sp = db.sanphams.Find(entity.ID);
                sp.MASP = entity.MASP;
                sp.TENSP = entity.TENSP;
                sp.GIAX = entity.GIAX;
                sp.GIA = entity.GIA;
                sp.SOLUONG = entity.SOLUONG;
                sp.NGAYNHAP = entity.NGAYNHAP;
                sp.ANH = entity.ANH;
                sp.MOTA = entity.MOTA;
                sp.MAHANGSX = entity.MAHANGSX;
                sp.MALOAI = entity.MALOAI;
                sp.TOPHOT = entity.TOPHOT;
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
                var tt = db.sanphams.Find(ID);
                db.sanphams.Remove(tt);
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
