using System.ComponentModel.DataAnnotations.Schema;

namespace FoodModel
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; } // navigation

        public int OrderId { get; set; }
        public Order? Order { get; set; } // navigation

        public int Quantity { get; set; }
        [Column("Price")]
        public decimal TotalPrice { get; set; } // Quantity * Price
    }
}