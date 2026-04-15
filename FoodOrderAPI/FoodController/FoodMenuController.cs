using FoodMenuSerInterface;
using FoodMenuDtoFile;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuControllerFile
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodMenuController : ControllerBase
    {
        private readonly IFoodMenuSer _service;

        public FoodMenuController(IFoodMenuSer service)
        {
            _service = service;
        }

        // Category endpoints
        [HttpGet("categories")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<ActionResult> AddCategory(CategoryDto category)
        {
            await _service.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("categories/{id}")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryDto category)
        {
            if (id != category.Id) return BadRequest();
            await _service.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("categories/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _service.DeleteCategoryAsync(id);
            return NoContent();
        }

        // MenuItem endpoints
        [HttpGet("menuitems")]
        public async Task<ActionResult<List<MenuItemDto>>> GetMenuItems()
        {
            var menuItems = await _service.GetMenuItemsAsync();
            return Ok(menuItems);
        }
        [HttpGet("menuitems/{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItemById(int id)
        {
            var menuItem = await _service.GetMenuItemByIdAsync(id);
            if (menuItem == null) return NotFound();
            return Ok(menuItem);
        }
        [HttpPost("menuitems")]
        public async Task<ActionResult> AddMenuItem(MenuItemDto menuItem)
        {
            await _service.AddMenuItemAsync(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItem.Id }, menuItem);
        }
        [HttpPut("menuitems/{id}")]
        public async Task<ActionResult> UpdateMenuItem(int id, MenuItemDto menuItem)
        {
            if (id != menuItem.Id) return BadRequest();
            await _service.UpdateMenuItemAsync(menuItem);
            return NoContent();
        }
        [HttpDelete("menuitems/{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            await _service.DeleteMenuItemAsync(id);
            return NoContent();
        }

        // Order endpoints
        [HttpGet("orders")]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _service.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
        // [HttpPost("orders")]
        // public async Task<ActionResult> AddOrder(OrderDto order)
        // {
        //     await _service.AddOrderAsync(order);
        //     return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        // }
        [HttpPost("orders")]
        public async Task<ActionResult> AddOrder(OrderDto order)
        {
            // 🔥 Generate Token using count
            var orders = await _service.GetAllOrdersAsync();
            int nextNumber = orders.Count + 1;

            order.TokenNumber = $"T{nextNumber:D3}"; // T001, T002...

            await _service.AddOrderAsync(order);

            return Ok(order);
        }
        [HttpPut("orders/{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderDto order)
        {
            if (id != order.Id) return BadRequest();
            await _service.UpdateOrderAsync(order);
            return NoContent();
        }
        [HttpDelete("orders/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _service.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}