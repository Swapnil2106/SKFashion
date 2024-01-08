using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
