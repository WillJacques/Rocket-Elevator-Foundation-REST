using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using Newtonsoft.Json.Linq;

namespace REST_API.Controllers
{
    [Route("api/interventions")]
    [ApiController]
    public class interventionsController : ControllerBase
    {
        private readonly REST_Context _context;

        public interventionsController(REST_Context context)
        {
            _context = context;
        }

        // GET: api/interventions/{status}
        [HttpGet("{status}")]
        public IEnumerable<intervention> Getintervention(string status)
        {   
            IQueryable<intervention> interventions = from intervention in _context.interventions.Where(intervention => intervention.status == status && intervention.intervention_start == null) select intervention;
            
            return interventions.ToList();
        }

        // PUT: api/intervention/InProgress/{id}
        [HttpPut("InProgress/{id}")]
        public async Task<IActionResult> InterventionInProgress(long id, intervention intervention)
        {
            var interventionInProgress = await _context.interventions.FindAsync(id);
            if (interventionInProgress == null) {return NotFound ();}

            DateTime aDate = DateTime.Now;

            interventionInProgress.status = intervention.status;
            interventionInProgress.intervention_start = aDate;

            _context.interventions.Update (interventionInProgress);
            _context.SaveChanges ();

            var status = new JObject ();
            status["message"] = "Status of Intervention #" + interventionInProgress.id + " changed to " + interventionInProgress.status;

            return Content (status.ToString (), "application/json");
        }

        // PUT: api/Intervention/Completed/{id}
        [HttpPut("Completed/{id}")]
        public async Task<IActionResult> InterventionCompleted(long id, intervention intervention)
        {
            var interventionCompleted = await _context.interventions.FindAsync (id);
            if (interventionCompleted == null) {return NotFound ();}

            DateTime aDate = DateTime.Now;
            interventionCompleted.status = intervention.status;
            interventionCompleted.intervention_stop = aDate;

            _context.interventions.Update (interventionCompleted);
            _context.SaveChanges ();

            var status = new JObject ();
            status["message"] = "Status of Intervention #" + interventionCompleted.id + " changed to " + interventionCompleted.status;

            return Content (status.ToString (), "application/json");
        }
    }
}
