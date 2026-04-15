using System.ComponentModel.DataAnnotations.Schema;

namespace FoodModel
{

    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}