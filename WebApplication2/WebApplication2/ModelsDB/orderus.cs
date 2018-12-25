namespace WebApplication2.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orderus
    {
        public int id { get; set; }

        public int? lot_id { get; set; }

        [StringLength(128)]
        public string employer_id { get; set; }

        [StringLength(128)]
        public string customer_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_selling { get; set; }

        public bool vir { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual AspNetUsers AspNetUsers1 { get; set; }

        public virtual lot lot { get; set; }
    }
}
