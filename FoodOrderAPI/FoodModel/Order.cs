using System.ComponentModel.DataAnnotations.Schema;

namespace FoodModel
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public required string GuestName { get; set; }
        public required string TokenNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        // Navigation
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}