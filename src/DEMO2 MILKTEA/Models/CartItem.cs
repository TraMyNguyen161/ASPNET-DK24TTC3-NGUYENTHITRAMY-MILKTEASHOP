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

        public int SugarLevel { get; set; }

        public int IceLevel { get; set; }

       
        public List<int> SelectedToppingIds { get; set; } = new List<int>();

        public CartItem Clone()
        {
            return new CartItem
            {
                ProductId = this.ProductId,
                ProductName = this.ProductName,
                Price = this.Price,
                Quantity = this.Quantity,
                ImageUrl = this.ImageUrl,
                Size = this.Size,
                SugarLevel = this.SugarLevel,
                IceLevel = this.IceLevel,
                SelectedToppingIds = new List<int>(this.SelectedToppingIds)
            };
        }
    }
}
