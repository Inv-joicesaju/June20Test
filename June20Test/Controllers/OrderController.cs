using June20Test.Data;
using June20Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace June20Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);
        public OrderController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _semaphore.WaitAsync(); // Wait for semaphore lock

            try
            {
                var addResult = _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return Ok(addResult.Entity);
            }
            finally
            {
                _semaphore.Release(); // Release the semaphore lock
            }
        }


        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var getOrders =  await _context.Orders.Include(o=>o.Product).ToListAsync();
            return Ok(getOrders);
        }



        ////////////////////////////////////////////////////////////////////////////////////


        [HttpPost("add")]
        public async Task<ActionResult<Order>> PostOrder(Order2 order)
        {
            try
            {
                await _semaphore.WaitAsync(); // Wait for semaphore

                // Validate the product exists
                var product = await _context.Products.FindAsync(order.ProductId);
                if (product == null)
                {
                    return NotFound($"Product with ID {order.ProductId} not found.");
                }

                // Calculate TotalAmount (assuming Price is a property in Product)
                order.TotalAmount = product.Price * order.Quantity;

                // Set OrderDate
                order.OrderDate = DateTime.UtcNow;

                // Add the order
                _context.order2s.Add(order);
                await _context.SaveChangesAsync();

                return Ok(order);
            }
            finally
            {
                _semaphore.Release(); // Release semaphore
            }
        }


        [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<IEnumerable<Order2>>> GetOrdersByProduct(int productId)
        {
            var orders = await _context.order2s.Include(o=>o.Product2)
                .Where(o => o.ProductId == productId)
                .ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                return NotFound($"No orders found for Product ID {productId}.");
            }

            return orders;
        }
    }
}
