using FoodModel;

namespace FoodMenuRepoInterface
{
    public interface IFoodMenuRepo
    {
        // Category
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);

        // MenuItem
        Task<List<MenuItem>> GetMenuItemsAsync();
        Task<MenuItem?> GetMenuItemByIdAsync(int menuItemId);
        Task AddMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int menuItemId);

        // Order
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
    }
}