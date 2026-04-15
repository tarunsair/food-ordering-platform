using FoodMenuDtoFile;

namespace FoodMenuSerInterface
{
    public interface IFoodMenuSer
    {
        // Category
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(CategoryDto category);
        Task UpdateCategoryAsync(CategoryDto category);
        Task DeleteCategoryAsync(int categoryId);

        // MenuItem
        Task<List<MenuItemDto>> GetMenuItemsAsync();
        Task<MenuItemDto?> GetMenuItemByIdAsync(int menuItemId);
        Task AddMenuItemAsync(MenuItemDto menuItem);
        Task UpdateMenuItemAsync(MenuItemDto menuItem);
        Task DeleteMenuItemAsync(int menuItemId);

        // Order
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(OrderDto order);
        Task UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int orderId);
    }
}