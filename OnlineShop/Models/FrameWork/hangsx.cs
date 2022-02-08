namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hangsx")]
    public partial class hangsx
    {
        public long ID { get; set; }

        [StringLength(15)]
        public string MAHANGSX { get; set; }

        [StringLength(50)]
        public string TENHANG { get; set; }

        [StringLength(100)]
        public string ANH { get; set; }

        public bool? TrangThai { get; set; }
    }
}
