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
    public class ElevatorController : ControllerBase
    {
        private readonly REST_Context _context;

        public ElevatorController(REST_Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }
        // GET: api/Elevator
        [HttpGet("Active")]
        public ActionResult<List<Elevator>> GetAll()
        {
            var list = _context.elevators.ToList(); // List of all the elevators in the database

            if (list == null)
            {
                return NotFound();
            }
            List<Elevator> inactive_elevator_list = new List<Elevator>(); // Elevators will be added in this list if they respect the requirements (If they don't have an ACTIVE status)
            // Add elevators in the list if they don't have an ACTIVE status
            foreach (var elevator in list)
            {
                if (elevator.elevator_status != "ACTIVE")
                {
                    inactive_elevator_list.Add(elevator);
                }
            }
            return inactive_elevator_list;
        }


        [HttpGet("Amount")]
        public async Task<IActionResult> getAmount()
        {
            var list = _context.elevators.ToList();
            var listCount = list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }

        [HttpGet("Inactive/Amount")]
        public async Task<IActionResult> getInactiveAmount()
        {
            var list = _context.elevators.ToList(); // List of all the elevators in the database

            if (list == null)
            {
                return NotFound();
            }
            List<Elevator> inactive_elevator_list = new List<Elevator>(); // Elevators will be added in this list if they respect the requirements (If they don't have an ACTIVE status)
            // Add elevators in the list if they don't have an ACTIVE status
            foreach (var elevator in list)
            {
                if (elevator.elevator_status != "ACTIVE")
                {
                    inactive_elevator_list.Add(elevator);
                }
            }

            var listCount = inactive_elevator_list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }

        // GET: api/Elevator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }
            // Create a message to show the new status
            var status = new JObject();
            status["status"] = elevator.elevator_status;
            return Content(status.ToString(), "application/json");
        }

        [HttpGet("forColumn/{id}")]
        public ActionResult<List<Elevator>> GetColumnElevator(long id)
        {
            // get a complete list of columns
            List<Elevator> elevatorsAll = _context.elevators.ToList();
            List<Elevator> columnsElevators = new List<Elevator>();
            // select relevant columns
            foreach (Elevator elevator in elevatorsAll)
            {
                if ((elevator.column_id) == id)
                {
                    // only add  that belong to desired elevator
                    columnsElevators.Add(elevator);
                }
            }
            return columnsElevators;

        }

        // PUT: api/Elevator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        {
            var e = await _context.elevators.FindAsync(id);
            if (e == null)
            {
                return NotFound();
            }

            e.elevator_status = elevator.elevator_status;

            _context.elevators.Update(e);
            _context.SaveChanges();

            // Create a message to show the new status
            var status = new JObject();
            status["message"] = "The status of the Elevator with the id number #" + e.Id + " have been changed to " + e.elevator_status;
            return Content(status.ToString(), "application/json");
        }
    }
}
