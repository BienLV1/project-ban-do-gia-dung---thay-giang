namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oderdetail")]
    public partial class oderdetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(100)]
        public string hoten { get; set; }

        [StringLength(50)]
        public string masp { get; set; }

        [StringLength(200)]
        public string tensp { get; set; }

        public int? soluong { get; set; }

        public long? giatien { get; set; }

        public bool? TrangThai { get; set; }
    }
}
