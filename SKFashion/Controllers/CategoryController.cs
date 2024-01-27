using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> FindCategory(int id)
        {
            var item = await _context.Category.FindAsync(id);
            if (item == null)
            {
                return NotFound("Category Not Found !!");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Category.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, Category category)
        {
            var item = await _context.Category.FindAsync(id);
            if (item == null)
            {
                return NotFound("Category Not Found !!");
            }

            item.CategoryName = category.CategoryName;
            item.CategoryDescription = category.CategoryDescription;

            await _context.SaveChangesAsync();

            return Ok(await _context.Category.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var item = await _context.Category.FindAsync(id);
            if (item == null)
            {
                return NotFound("Category Not Found !!");
            }

            _context.Category.Remove(item);

            await _context.SaveChangesAsync();

            return Ok(await _context.Category.ToListAsync());
        }
    }
}
