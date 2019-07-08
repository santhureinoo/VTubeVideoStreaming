namespace WebApplication1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Series
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Series()
        {
            Seasons = new HashSet<Season>();
        }

        public int ID { get; set; }

        public byte[] Poster { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int Rating { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Season> Seasons { get; set; }

        public virtual Series Series1 { get; set; }

        public virtual Series Series2 { get; set; }

        public virtual Series Series11 { get; set; }

        public virtual Series Series3 { get; set; }
    }
}
