namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [Column(TypeName = "ntext")]
        public string ND { get; set; }

        public bool? TrangThai { get; set; }
    }
}
