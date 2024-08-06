using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Nwu_Tech_Trends.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly ApplicationDbContext _context;

        public TelemetryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telemetry>> GetAllTelemetryAsync()
        {
            return await _context.Telemetries.ToListAsync();
        }

        public async Task<Telemetry> GetTelemetryByIdAsync(int id)
        {
            return await _context.Telemetries.FindAsync(id);
        }

        public async Task<Telemetry> CreateTelemetryAsync(Telemetry telemetry)
        {
            _context.Telemetries.Add(telemetry);
            await _context.SaveChangesAsync();
            return telemetry;
        }

        public async Task UpdateTelemetryAsync(int id, Telemetry telemetry)
        {
            var existingTelemetry = await _context.Telemetries.FindAsync(id);
            if (existingTelemetry == null) return;

            existingTelemetry.ProjectId = telemetry.ProjectId;
            existingTelemetry.ClientId = telemetry.ClientId;
            existingTelemetry.TimeSaved = telemetry.TimeSaved;
            existingTelemetry.CostSaved = telemetry.CostSaved;

            _context.Entry(existingTelemetry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelemetryAsync(int id)
        {
            var telemetry = await _context.Telemetries.FindAsync(id);
            if (telemetry == null) return;

            _context.Telemetries.Remove(telemetry);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TelemetryExistsAsync(int id)
        {
            return await _context.Telemetries.AnyAsync(e => e.Id == id);
        }

        public async Task<SavingsResponse> GetSavingsByProjectAsync(int projectId, DateTime startDate, DateTime endDate)
        {
            var telemetryEntries = await _context.Telemetries
                .Where(t => t.ProjectId == projectId && t.Date >= startDate && t.Date <= endDate)
                .ToListAsync();

            return new SavingsResponse
            {
                TotalTimeSaved = telemetryEntries.Sum(t => t.TimeSaved.TotalMinutes),
                TotalCostSaved = telemetryEntries.Sum(t => t.CostSaved)
            };
        }

        public async Task<SavingsResponse> GetSavingsByClientAsync(int clientId, DateTime startDate, DateTime endDate)
        {
            var telemetryEntries = await _context.Telemetries
                .Where(t => t.ClientId == clientId && t.Date >= startDate && t.Date <= endDate)
                .ToListAsync();

            return new SavingsResponse
            {
                TotalTimeSaved = telemetryEntries.Sum(t => t.TimeSaved.TotalMinutes),
                TotalCostSaved = telemetryEntries.Sum(t => t.CostSaved)
            };
        }
    }
}
