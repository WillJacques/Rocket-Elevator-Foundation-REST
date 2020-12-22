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
    public class BuildingController : ControllerBase
    {
        private readonly REST_Context _context;

        public BuildingController(REST_Context context)
        {
            _context = context;
        }

        [HttpGet("Amount")]
        public async Task<IActionResult> getAmount()
        {
            var list = _context.buildings.ToList();
            var listCount = list.Count;
            var amount = new JObject();
            amount["amount"] = listCount;
            return Content(amount.ToString(), "application/json");
        }

        // GET: api/Building
        [HttpGet]
        public ActionResult<List<Building>> GetAll()
        {
            var list_el = _context.elevators.ToList(); // List of all the elevators in the database
            var list_co = _context.columns.ToList(); // List of all the columns in the database
            var list_ba = _context.batteries.ToList(); // List of all the batteries in the database
            var list_bu = _context.buildings.ToList(); // List of all the buildings in the database
            List<Elevator> intervention_elevator = new List<Elevator>(); // Elevators will be added in this list if they respect the requirements (If they have an intervention status)
            List<Column> intervention_column = new List<Column>(); // Columns will be added in this list if they respect the requirements (If they have an intervention status)
            List<Battery> intervention_battery = new List<Battery>(); // Batteries will be added in this list if they respect the requirements (If they have an intervention status)
            List<Building> intervention_building = new List<Building>(); // // Buildings will be added in this list if they have at least a battery, column or elevator with an intervention status.

            // Add elevators with an intervention status in the list
            foreach (var elevator in list_el)
            {
                if (elevator.status == "Intervention")
                {
                    intervention_elevator.Add(elevator);
                }
            }
            // Add columns in the list if they have an elevator with an intervention status
            foreach (var elevator in intervention_elevator)
            {
                foreach (var column in list_co)
                {
                    if (column.Id == elevator.column_id)
                    {
                        intervention_column.Add(column);
                    }
                }
            }
            // Add columns with an intervention status in the list
            foreach (var column in list_co)
            {
                if (column.column_status == "Intervention")
                {
                    intervention_column.Add(column);
                }
            }
            // Add batteries in the list if they have a column with an intervention status
            foreach (var column in intervention_column)
            {
                foreach (var battery in list_ba)
                {
                    if (battery.Id == column.battery_id)
                    {
                        intervention_battery.Add(battery);
                    }
                }
            }
            // Add batteries with an intervention status in the list
            foreach (var battery in list_ba)
            {
                if (battery.battery_status == "Intervention")
                {
                    intervention_battery.Add(battery);
                }
            }
            // Add buildings in the list if they have a battery with an intervention status
            foreach (var battery in intervention_battery)
            {
                foreach (var building in list_bu)
                {
                    if (building.Id == battery.building_id)
                    {
                        intervention_building.Add(building);
                    }
                }
            }
            // Remove any duplicate buildings in the list
            List<Building> all_building = intervention_building.Distinct().ToList();
            return all_building;
        }
        [HttpGet("forBuilding/{id}")]
        public ActionResult<List<Building>> GetCustomerBuilding(long id)
        {
            // get a complete list of columns
            List<Building> buildingsAll = _context.buildings.ToList();
            List<Building> customerBuildings = new List<Building>();
            // select relevant columns
            foreach (Building building in buildingsAll)
            {
                if ((building.customer_id) == id)
                {
                    // only add  that belong to desired building
                    customerBuildings.Add(building);
                }
            }
            return customerBuildings;

        }
    }
}
