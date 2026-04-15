using FoodMenuRepoInterface;
using FoodMenuSerInterface;
using FoodMenuDtoFile;
using FoodModel;

namespace FoodMenuSerImplementation
{
    public class FoodMenuSer : IFoodMenuSer
    {
        private readonly IFoodMenuRepo _repo;

        public FoodMenuSer(IFoodMenuRepo repo)
        {
            _repo = repo;
        }

            // ----------------- Category -----------------
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repo.GetAllCategoriesAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
                }).ToList();
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _repo.GetCategoryByIdAsync(categoryId);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task AddCategoryAsync(CategoryDto category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };
            await _repo.AddCategoryAsync(newCategory);
        }
        public async Task UpdateCategoryAsync(CategoryDto category)
        {
            var existingCategory = await _repo.GetCategoryByIdAsync(category.Id);
            if (existingCategory == null) return;

            existingCategory.Name = category.Name;
            await _repo.UpdateCategoryAsync(existingCategory);
        }
        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repo.DeleteCategoryAsync(categoryId);
        }

        // ----------------- MenuItem -----------------
        public async Task<List<MenuItemDto>> GetMenuItemsAsync()
        {
            var menuItems = await _repo.GetMenuItemsAsync();
            return menuItems.Select(m => new MenuItemDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                CategoryId = m.CategoryId,
                ImageUrl = m.ImageUrl
            }).ToList();
        }
        public async Task<MenuItemDto?> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _repo.GetMenuItemByIdAsync(menuItemId);
            if (menuItem == null) return null;

            return new MenuItemDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                CategoryId = menuItem.CategoryId,
                ImageUrl = menuItem.ImageUrl
            };
        }
        public async Task AddMenuItemAsync(MenuItemDto menuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                CategoryId = menuItem.CategoryId,
                ImageUrl = menuItem.ImageUrl
            };
            await _repo.AddMenuItemAsync(newMenuItem);
        }
        public async Task UpdateMenuItemAsync(MenuItemDto menuItem)
        {
            var existingMenuItem = await _repo.GetMenuItemByIdAsync(menuItem.Id);
            if (existingMenuItem == null) return;

            existingMenuItem.Name = menuItem.Name;
            existingMenuItem.Description = menuItem.Description;
            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.CategoryId = menuItem.CategoryId;

            await _repo.UpdateMenuItemAsync(existingMenuItem);
        }
        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            await _repo.DeleteMenuItemAsync(menuItemId);
        }
        // ----------------- Order -----------------
        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _repo.GetAllOrdersAsync();
            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                GuestName = o.GuestName,
                TokenNumber = o.TokenNumber,
                TotalAmount = o.TotalAmount,
                CreatedTime = o.CreatedTime,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    MenuItemId = oi.MenuItemId,
                    Quantity = oi.Quantity,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            }).ToList();
        }
        public async Task<OrderDto?> GetOrderByIdAsync(int orderId)
        {
            var order = await _repo.GetOrderByIdAsync(orderId);
            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                GuestName = order.GuestName,
                TokenNumber = order.TokenNumber,
                TotalAmount = order.TotalAmount,
                CreatedTime = order.CreatedTime,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    MenuItemId = oi.MenuItemId,
                    Quantity = oi.Quantity,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            };
        }
        public async Task AddOrderAsync(OrderDto order)
        {
            var newOrder = new Order
            {
                GuestName = order.GuestName,
                TokenNumber = order.TokenNumber,
                TotalAmount = order.TotalAmount,
                CreatedTime = order.CreatedTime,
                OrderItems = order.OrderItems.Select(oi => new OrderItem
                {
                    MenuItemId = oi.MenuItemId,
                    Quantity = oi.Quantity,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            };
            await _repo.AddOrderAsync(newOrder);
        }
        public async Task UpdateOrderAsync(OrderDto order)
        {
            var existingOrder = await _repo.GetOrderByIdAsync(order.Id);
            if (existingOrder == null) return;

            existingOrder.GuestName = order.GuestName;
            existingOrder.TokenNumber = order.TokenNumber;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.CreatedTime = order.CreatedTime;

            // For simplicity, we won't handle updating OrderItems here

            await _repo.UpdateOrderAsync(existingOrder);
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            await _repo.DeleteOrderAsync(orderId);
        }
    }

}