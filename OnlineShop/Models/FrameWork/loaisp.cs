namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaisp")]
    public partial class loaisp
    {
        public long ID { get; set; }

        [StringLength(15)]
        public string MALOAI { get; set; }

        [StringLength(50)]
        public string TENLOAI { get; set; }

        public bool? TrangThai { get; set; }
    }
}
