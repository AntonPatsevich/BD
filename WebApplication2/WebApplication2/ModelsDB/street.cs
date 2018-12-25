namespace WebApplication2.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("street")]
    public partial class street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public street()
        {
            lot = new HashSet<lot>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string street_def { get; set; }

        public int? district_id { get; set; }

        public virtual district district { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lot> lot { get; set; }
    }
}
