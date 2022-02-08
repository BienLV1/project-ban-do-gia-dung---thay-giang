namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        public long ID { get; set; }

        [StringLength(15)]
        public string MASP { get; set; }

        [StringLength(100)]
        public string TENSP { get; set; }

        public long? GIAX { get; set; }

        public long? GIA { get; set; }

        public int? GIAMGIA { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }

        [StringLength(100)]
        public string ANH { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA { get; set; }

        public long? MAHANGSX { get; set; }

        public long? MALOAI { get; set; }

        public DateTime? TOPHOT { get; set; }

        public bool? TrangThai { get; set; }
    }
}
