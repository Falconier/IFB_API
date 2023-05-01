namespace IFB_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }
    }
}
