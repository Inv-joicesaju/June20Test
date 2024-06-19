using June20Test.Data;
using June20Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace June20Test.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {
        private readonly AppDbContext _context;
        public SellerController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateSeller(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =  _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
        {
            return await _context.Sellers
               .Select(seller => new Seller
               {
                   SellerId = seller.SellerId,
                   Name = seller.Name,
                   Email = seller.Email,
                   Phone = seller.Phone
               })
               .ToListAsync();
        }

    }
}
