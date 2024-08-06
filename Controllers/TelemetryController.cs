using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nwu_Tech_Trends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService; // Assumed service layer

        public TelemetryController(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        // GET: api/telemetry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telemetry>>> GetAllTelemetry()
        {
            var telemetryEntries = await _telemetryService.GetAllTelemetryAsync();
            return Ok(telemetryEntries);
        }

        // GET: api/telemetry/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Telemetry>> GetTelemetryById(int id)
        {
            var telemetryEntry = await _telemetryService.GetTelemetryByIdAsync(id);
            if (telemetryEntry == null)
            {
                return NotFound();
            }
            return Ok(telemetryEntry);
        }

        // POST: api/telemetry
        [HttpPost]
        public async Task<ActionResult<Telemetry>> CreateTelemetry([FromBody] Telemetry telemetry)
        {
            var createdTelemetry = await _telemetryService.CreateTelemetryAsync(telemetry);
            return CreatedAtAction(nameof(GetTelemetryById), new { id = createdTelemetry.Id }, createdTelemetry);
        }

        // PATCH: api/telemetry/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTelemetry(int id, [FromBody] Telemetry telemetry)
        {
            if (!await _telemetryService.TelemetryExistsAsync(id))
            {
                return NotFound();
            }
            await _telemetryService.UpdateTelemetryAsync(id, telemetry);
            return NoContent();
        }

        // DELETE: api/telemetry/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelemetry(int id)
        {
            if (!await _telemetryService.TelemetryExistsAsync(id))
            {
                return NotFound();
            }
            await _telemetryService.DeleteTelemetryAsync(id);
            return NoContent();
        }

        // GET: api/telemetry/savings/project
        [HttpGet("savings/project")]
        public async Task<ActionResult<SavingsResponse>> GetSavingsByProject([FromQuery] int projectId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var savings = await _telemetryService.GetSavingsByProjectAsync(projectId, startDate, endDate);
            return Ok(savings);
        }

        // GET: api/telemetry/savings/client
        [HttpGet("savings/client")]
        public async Task<ActionResult<SavingsResponse>> GetSavingsByClient([FromQuery] int clientId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var savings = await _telemetryService.GetSavingsByClientAsync(clientId, startDate, endDate);
            return Ok(savings);
        }

        // Private method to check if telemetry exists
        private async Task<bool> TelemetryExists(int id)
        {
            return await _telemetryService.TelemetryExistsAsync(id);
        }
    }

    public class Telemetry
    {
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string ClientId { get; set; }
        public TimeSpan TimeSaved { get; set; }
        public decimal CostSaved { get; set; }
        // Other properties as needed
    }

    public class SavingsResponse
    {
        public decimal TotalTimeSaved { get; set; }
        public decimal TotalCostSaved { get; set; }
    }
}
