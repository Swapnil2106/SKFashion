using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }
    }
}
