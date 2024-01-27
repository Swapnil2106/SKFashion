using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
              _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> FindProduct(int id)
        {
            var item = await _context.Product.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();  
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
        {
            var item = await _context.Product.FindAsync(id);
            if (item == null)
            {
                return NotFound("Product Not Found !!");
            }

            item.ProductName = product.ProductName;
            item.Price = product.Price;
            item.Stock = product.Stock;
            item.Description = product.Description;
            item.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var item = await _context.Product.FindAsync(id);
            if (item == null)
            {
                return NotFound("Product Not Found !!");
            }

            _context.Product.Remove(item);

            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());
        }

    }
}
