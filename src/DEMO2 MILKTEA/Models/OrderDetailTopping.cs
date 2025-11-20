using DEMO2_MILKTEA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models
{
    [Table("OrderDetail_Toppings")]
    public partial class OrderDetailTopping
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("OrderDetailID")]
        public int? OrderDetailId { get; set; }

        [Column("ToppingID")]
        public int? ToppingId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceAtOrder { get; set; }

        [ForeignKey("OrderDetailId")]
        public virtual OrderDetail? OrderDetail { get; set; }

        [ForeignKey("ToppingId")]
        public virtual Topping? Topping { get; set; }
    }
}