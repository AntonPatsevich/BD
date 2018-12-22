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

        public int? employer_id { get; set; }

        public int? customer_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_selling { get; set; }

        public virtual customer customer { get; set; }

        public virtual employer employer { get; set; }

        public virtual lot lot { get; set; }
    }
}
