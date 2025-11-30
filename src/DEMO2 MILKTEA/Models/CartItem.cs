using System.Collections.Generic;

namespace MILKTEASHOP.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public string Size { get; set; } = string.Empty;

        public string SugarLevel { get; set; } = string.Empty;

        public string IceLevel { get; set; } = string.Empty;

        public List<int> SelectedToppingIds { get; set; } = new List<int>();
    }


}
