namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("binhluan")]
    public partial class binhluan
    {
        public long ID { get; set; }

        [StringLength(1000)]
        public string NDBL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYDANG { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string ANH { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        public bool? TrangThai { get; set; }
    }
}
