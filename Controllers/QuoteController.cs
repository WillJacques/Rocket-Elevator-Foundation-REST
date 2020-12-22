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
    public class QuoteController : ControllerBase
    {
        private readonly REST_Context _context;

        public QuoteController(REST_Context context)
        {
            _context = context;
        }

        // GET: api/Quote
        [HttpGet("Amount")]
        public async Task<IActionResult> getAmount()
        {
            var list = _context.quotes.ToList();
            var listCount = list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }

        // GET: api/Quote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(long id)
        {
            var quote = await _context.quotes.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quote/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(long id, Quote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest();
            }

            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        // POST: api/Quote
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            _context.quotes.Add(quote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuote", new { id = quote.Id }, quote);
        }

        // DELETE: api/Quote/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> DeleteQuote(long id)
        {
            var quote = await _context.quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return quote;
        }

        private bool QuoteExists(long id)
        {
            return _context.quotes.Any(e => e.Id == id);
        }
    }
}
