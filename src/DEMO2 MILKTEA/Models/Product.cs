using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models
{
    [Table("Products")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int ProductId { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; } = null!;

        // ===== THÊM DESCRIPTION =====
        [StringLength(2000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasePrice { get; set; }

        [StringLength(500)]
        [Column("ImageURL")]
        public string? ImageUrl { get; set; }

        public bool? IsActive { get; set; }

        // QUAN HỆ
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
