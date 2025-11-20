using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Cần cái này
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models // <--- Kiểm tra kỹ dòng này
{
    [Table("OrderDetails")]
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderDetailToppings = new HashSet<OrderDetailTopping>();
        }

        [Key] // <--- QUAN TRỌNG: Xác định khóa chính
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        [StringLength(10)]
        public string? Size { get; set; }

        public int? SugarLevel { get; set; }
        public int? IceLevel { get; set; }

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