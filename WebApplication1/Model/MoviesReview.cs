namespace WebApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoviesReview")]
    public partial class MoviesReview
    {
        public int ID { get; set; }

        public string Comment { get; set; }

        public int UserID { get; set; }

        public DateTime Date { get; set; }

        public int MovieID { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
