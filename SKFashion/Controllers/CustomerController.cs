using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> FindCustomer(int id)
        {
            var item = await _context.Customer.FindAsync(id);
            if (item == null)
            {
                return NotFound("Customer Not Found !!");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customer.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, Customer customer)
        {
            var item = await _context.Customer.FindAsync(id);
            if (item == null)
            {
                return NotFound("Customer Not Found !!");
            }

            item.FirstName = customer.FirstName;
            item.LastName = customer.LastName;
            item.Email = customer.Email;
            item.PhoneNumber = customer.PhoneNumber;
            item.Gender = customer.Gender;
            item.DateOfBirth = customer.DateOfBirth;
            item.AddressId = customer.AddressId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Customer.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var item = await _context.Customer.FindAsync(id);
            if (item == null)
            {
                return NotFound("Customer Not Found !!");
            }

            _context.Customer.Remove(item);

            await _context.SaveChangesAsync();

            return Ok(await _context.Customer.ToListAsync());
        }
    }
}
