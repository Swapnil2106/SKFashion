using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKFashion.Models;

namespace SKFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddresses()
        {
            return await _context.Address.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> FindAddress(int id)
        {
            var item = await _context.Address.FindAsync(id);
            if (item == null)
            {
                return NotFound("Address Not Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Address>>> AddAddress(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
            return Ok(await _context.Address.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Address>>> UpdateAddress(int id, Address address)
        {
            var item = await _context.Address.FindAsync(id);
            if (item == null)
            {
                return NotFound("Address Not Found !!");
            }

            item.BuildingNumber = address.BuildingNumber;
            item.StreetAddress = address.StreetAddress;
            item.City = address.City;
            item.State = address.State;
            item.Country = address.Country;
            item.PinCode = address.PinCode;
            item.CustomerId = address.CustomerId;


            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Address>>> DeleteAddress(int id)
        {
            var item = await _context.Address.FindAsync(id);
            if (item == null)
            {
                return NotFound("Address Not Found !!");
            }

            _context.Address.Remove(item);

            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }
    }
}
