using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.FrameWork
{
    public partial class OnlineShopContextDb : DbContext
    {
        public OnlineShopContextDb()
            : base("name=OnlineShopContextDb1")
        {
        }

        public virtual DbSet<binhluan> binhluans { get; set; }
        public virtual DbSet<hangsx> hangsxes { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaisp> loaisps { get; set; }
        public virtual DbSet<loaitintuc> loaitintucs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<oder> oders { get; set; }
        public virtual DbSet<oderdetail> oderdetails { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<binhluan>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<binhluan>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<binhluan>()
                .Property(e => e.ANH)
                .IsUnicode(false);

            modelBuilder.Entity<hangsx>()
                .Property(e => e.MAHANGSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<hangsx>()
                .Property(e => e.ANH)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<loaisp>()
                .Property(e => e.MALOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<loaitintuc>()
                .Property(e => e.LOAITIN)
                .IsUnicode(false);

            modelBuilder.Entity<loaitintuc>()
                .Property(e => e.TENLOAITIN)
                .IsUnicode(false);

            modelBuilder.Entity<oder>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<oder>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<oder>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<oder>()
                .Property(e => e.thanhtoan)
                .IsUnicode(false);

            modelBuilder.Entity<oderdetail>()
                .Property(e => e.masp)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.MASP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.ANH)
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.MATIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.ANH)
                .IsUnicode(false);

            modelBuilder.Entity<tintuc>()
                .Property(e => e.LOAITIN)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);
        }
    }
}
