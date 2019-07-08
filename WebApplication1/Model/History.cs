namespace WebApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int MovieID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
