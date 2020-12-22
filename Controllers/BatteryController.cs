using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private readonly REST_Context _context;

        public BatteryController(REST_Context context)
        {
            _context = context;
        }

        // GET: api/Battery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> Getbatteries()
        {
            return await _context.batteries.ToListAsync();
        }

        [HttpGet("Amount")]
        public async Task<IActionResult> getAmount()
        {
            var list = _context.batteries.ToList();
            var listCount = list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }

        // GET: api/Battery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> GetBattery(long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }
            // Create a message to show the new status
            var status = new JObject();
            status["status"] = battery.battery_status;
            return Content(status.ToString(), "application/json");
        }

        [HttpGet("forBattery/{id}")]
        public ActionResult<List<Battery>> GetCustomerBuilding(long id)
        {
            // get a complete list of columns
            List<Battery> buildingsAll = _context.batteries.ToList();
            List<Battery> customerBuildings = new List<Battery>();
            // select relevant columns
            foreach (Battery battery in buildingsAll)
            {
                if ((battery.building_id) == id)
                {
                    // only add  that belong to desired battery
                    customerBuildings.Add(battery);
                }
            }
            return customerBuildings;

        }

        // PUT: api/Battery/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery(long id, Battery battery)
        {
            var b = await _context.batteries.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }

            b.battery_status = battery.battery_status;

            _context.batteries.Update(b);
            _context.SaveChanges();
            // Create a message to show the new status
            var status = new JObject();
            status["message"] = "The status of the Battery with the id number #" + b.Id + " have been changed to " + battery.battery_status;
            return Content(status.ToString(), "application/json");

        }

    }
}
