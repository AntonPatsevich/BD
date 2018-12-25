namespace WebApplication2.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lot")]
    public partial class lot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lot()
        {
            orderus = new HashSet<orderus>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string name_lot { get; set; }

        [Required]
        [StringLength(150)]
        public string Descriptionn { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public decimal? area { get; set; }

        public int? typeid { get; set; }

        public int likes { get; set; }

        public int? street_id { get; set; }

        public int number_house { get; set; }

        public int? number_flat { get; set; }

        public int? count_rooms { get; set; }
        public string userId { get; set; }
        public string FolderImg { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual street street { get; set; }

        public virtual lots_type lots_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderus> orderus { get; set; }
    }
}
