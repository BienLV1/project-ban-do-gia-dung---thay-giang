namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tintuc")]
    public partial class tintuc
    {
        public long ID { get; set; }

        [StringLength(15)]
        public string MATIN { get; set; }

        [Column(TypeName = "ntext")]
        public string TIEUDE { get; set; }

        [StringLength(100)]
        public string ANH { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYDANG { get; set; }

        [Column(TypeName = "ntext")]
        public string NDNGAN { get; set; }

        [StringLength(10)]
        public string LOAITIN { get; set; }

        public bool? TrangThai { get; set; }
    }
}
