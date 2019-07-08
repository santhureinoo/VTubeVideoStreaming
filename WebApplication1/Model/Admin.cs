namespace WebApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Display { get; set; }

        [Column(Order = 2)]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
