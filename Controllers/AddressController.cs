using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Models;
using Newtonsoft.Json.Linq;


namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly REST_Context _context;

        public AddressController(REST_Context context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Getaddresses()
        {
            return await _context.addresses.ToListAsync();
        }

        [HttpGet("Amount")]
        public async Task<IActionResult> getCitiesAll()
        {
            var allAdresses = _context.addresses.ToList();

            var allCities = allAdresses.GroupBy(x => x.city).Select(g => g.First()).ToList();

            var citiesCount = allCities.Count;

            var amount = new JObject();
            amount["amount"] = citiesCount;
            return Content(amount.ToString(), "application/json");

        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(long id)
        {
            var address = await _context.addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(long id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(long id)
        {
            var address = await _context.addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.addresses.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(long id)
        {
            return _context.addresses.Any(e => e.Id == id);
        }
    }
}
