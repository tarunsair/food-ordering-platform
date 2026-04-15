using System.ComponentModel.DataAnnotations.Schema;

namespace FoodModel
{
    
    [Table("MenuItem")]
    public class MenuItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        [Column("IsVeg")]
        public bool IsVegetarian { get; set; } = false;
        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}