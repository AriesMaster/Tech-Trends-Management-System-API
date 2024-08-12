using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nwu_Tech_Trends.dBContexts;
using Nwu_Tech_Trends.Models; // Importing the correct namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;



namespace JWTAuthentication.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly NWUDATABASEContext _context;

        public TelemetryController(NWUDATABASEContext context)
        {
            _context = context;
        }

        // GET: api/Telemetry
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            var jobTelemetries = await _context.JobTelemetries.ToListAsync();
            return Ok(jobTelemetries);
        }

        // GET: api/Telemetry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound(new { Message = $"Telemetry entry with ID {id} not found." });
            }

            return Ok(jobTelemetry);
        }

        // POST: api/Telemetry
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            if (jobTelemetry == null)
            {
                return BadRequest(new { Message = "Telemetry data cannot be null." });
            }

            jobTelemetry.EntryDate = jobTelemetry.EntryDate.Date;

            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobTelemetry), new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // PATCH: api/Telemetry/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest(new { Message = "ID mismatch." });
            }

            var existingTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (existingTelemetry == null)
            {
                return NotFound(new { Message = $"Telemetry entry with ID {id} not found." });
            }

            _context.Entry(existingTelemetry).CurrentValues.SetValues(jobTelemetry);

            existingTelemetry.EntryDate = existingTelemetry.EntryDate.Date;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
                {
                    return NotFound(new { Message = $"Telemetry entry with ID {id} not found." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Telemetry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound(new { Message = $"Telemetry entry with ID {id} not found." });
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        // GET: api/Telemetry/GetSavingsByProject
        [HttpGet("GetSavingsByProject")]
        public async Task<ActionResult<object>> GetSavingsByProject(Guid projectId, DateTime startDate)
        {
            if (startDate == default)
            {
                return BadRequest(new { Message = "Start date cannot be empty." });
            }

            var endDate = DateTime.Now;

            var savings = await _context.JobTelemetries
                .Where(t => t.ProcessId == projectId &&
                            t.EntryDate >= startDate.Date &&
                            t.EntryDate <= endDate.Date)
                .GroupBy(t => t.ProcessId)
                .Select(g => new
                {
                    ProjectId = g.Key,
                    TotalTimeSaved = g.Sum(t => t.HumanTime),
                    TotalCostSaved = g.Sum(t => t.HumanTime) * 0.1 // Example cost calculation
                })
                .FirstOrDefaultAsync();

            if (savings == null)
            {
                return NotFound(new { Message = $"No savings data found for Project ID {projectId} within the specified date range." });
            }

            return Ok(savings);
        }

        // GET: api/Telemetry/GetSavingsByClient
        [HttpGet("GetSavingsByClient")]
        public async Task<ActionResult<object>> GetSavingsByClient(string clientId, DateTime startDate)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                return BadRequest(new { Message = "Client ID cannot be empty." });
            }

            if (startDate == default)
            {
                return BadRequest(new { Message = "Start date cannot be empty." });
            }

            var endDate = DateTime.Now;

            var savings = await _context.JobTelemetries
                .Where(t => t.UniqueReference == clientId &&
                            t.EntryDate >= startDate.Date &&
                            t.EntryDate <= endDate.Date)
                .GroupBy(t => t.UniqueReference)
                .Select(g => new
                {
                    ClientId = g.Key,
                    TotalTimeSaved = g.Sum(t => t.HumanTime),
                    TotalCostSaved = g.Sum(t => t.HumanTime) * 0.1 // Example cost calculation
                })
                .FirstOrDefaultAsync();

            if (savings == null)
            {
                return NotFound(new { Message = $"No savings data found for Client ID {clientId} within the specified date range." });
            }

            return Ok(savings);
        }
    }
}
