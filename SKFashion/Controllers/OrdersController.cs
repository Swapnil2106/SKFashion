using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }
    }
}
