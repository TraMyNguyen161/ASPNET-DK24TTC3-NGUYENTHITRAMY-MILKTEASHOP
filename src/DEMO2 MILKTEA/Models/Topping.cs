using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MILKTEASHOP.Models
{
    [Table("Toppings")]
    public partial class Topping
    {
        public Topping()
        {
            OrderDetailToppings = new HashSet<OrderDetailTopping>();
        }

        [Key]
        public int ToppingId { get; set; }

        [Required]
        [StringLength(100)]
        public string ToppingName { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetailTopping> OrderDetailToppings { get; set; }
    }
}