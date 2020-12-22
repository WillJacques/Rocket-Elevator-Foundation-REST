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
    public class CustomerController : ControllerBase
    {
        private readonly REST_Context _context;

        public CustomerController(REST_Context context)
        {
            _context = context;
        }


        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

        [HttpGet("Amount")]
        public async Task<IActionResult> getAmount()
        {
            var list = _context.customers.ToList();
            var listCount = list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }
        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            var email = new JObject();
            email["company_contact_email"] = customer.company_contact_email;
            return Content(email.ToString(), "application/json");
        }
        [HttpGet("Email/{company_contact_email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string company_contact_email)
        {
            var customer = await _context.customers.FindAsync(company_contact_email);

            if (customer == null)
            {
                return NotFound();
            }
            var email = new JObject();
            email["company_contact_email"] = customer.company_contact_email;
            return Content(email.ToString(), "application/json");
        }
        // PUT: api/Customer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(long id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(long id)
        {
            return _context.customers.Any(e => e.Id == id);
        }
    }
}
