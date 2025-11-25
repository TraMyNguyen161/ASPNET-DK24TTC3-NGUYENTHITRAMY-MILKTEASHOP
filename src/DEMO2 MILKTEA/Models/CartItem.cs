using System.ComponentModel.DataAnnotations;

namespace MILKTEASHOP.Models
{
    public class CartItem
    {
        [Key] // <--- QUAN TRỌNG: Xác định khóa chính
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
