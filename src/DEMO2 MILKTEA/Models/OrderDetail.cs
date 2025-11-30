using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models 
{
    [Table("OrderDetails")]
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderDetailToppings = new HashSet<OrderDetailTopping>();
        }

        [Key] 
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        [StringLength(10)]
        public string Size { get; set; } = string.Empty;
        public string SugarLevel { get; set; } = string.Empty;
        public string IceLevel { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceAtOrder { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public virtual ICollection<OrderDetailTopping> OrderDetailToppings { get; set; }
    }
}