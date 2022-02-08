namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaitintuc")]
    public partial class loaitintuc
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string LOAITIN { get; set; }

        [Column(TypeName = "text")]
        public string TENLOAITIN { get; set; }
    }
}
