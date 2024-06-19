using June20Test.Data;
using June20Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace June20Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var addResult  =  _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(addResult.Entity);   
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }



        /////////////////////////////////////////////////////////////////

        [HttpPost("add")]
        public async Task<ActionResult<Product>> PostProduct(Product2 product)
        {
            // Check if the seller exists
            var seller = await _context.Sellers.FindAsync(product.SellerId);
            if (seller == null)
            {
                return NotFound($"Seller with ID {product.SellerId} not found.");
            }

            // Add the product
            _context.Product2s.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }




        [HttpGet("orders")]
        public async Task<ActionResult<Product>> GetProductsBYId(int sellerId)
        {
            var sellerProducts = await _context.Product2s
                .Where(p => p.SellerId == sellerId)
                .ToListAsync();

            return Ok(sellerProducts);
        }



    }
}
