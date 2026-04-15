namespace FoodMenuDtoFile
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
    public class MenuItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }

        public bool IsVegetarian { get; set; } = false;
        // Foreign Key
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } // for easier display
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public required string GuestName { get; set; }
        public required string TokenNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        // Navigation
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }

        public class OrderItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } // Quantity * Price
    }
}