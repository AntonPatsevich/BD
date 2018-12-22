namespace WebApplication2.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("district")]
    public partial class district
    {
        public int id { get; set; }

        [StringLength(50)]
        public string district_def { get; set; }

        public int? count_sells_objects { get; set; }
    }
}
