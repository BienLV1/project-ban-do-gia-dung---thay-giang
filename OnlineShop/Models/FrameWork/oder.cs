namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oder")]
    public partial class oder
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public double? total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydathang { get; set; }

        [Column(TypeName = "text")]
        public string thanhtoan { get; set; }

        public bool? TrangThai { get; set; }
    }
}
