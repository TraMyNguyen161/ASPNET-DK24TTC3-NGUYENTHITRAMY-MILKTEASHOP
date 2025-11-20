using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;       // Cần cái này để dùng [Key]
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models // <--- Nhớ kiểm tra Namespace phải trùng với mấy file kia
{
    [Table("Orders")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key] // <--- QUAN TRỌNG: Đây là dòng xác định khóa chính
        public int OrderId { get; set; }

        [StringLength(100)]
        public string? CustomerName { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(500)]
        public string? ShippingAddress { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalAmount { get; set; }

        public int? Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}