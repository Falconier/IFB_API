namespace IFB_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UPC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SKU { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public decimal Unit_Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal On_Hand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
