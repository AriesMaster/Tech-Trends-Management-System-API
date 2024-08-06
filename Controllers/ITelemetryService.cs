using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nwu_Tech_Trends.Services
{
    public interface ITelemetryService
    {
        Task<IEnumerable<Telemetry>> GetAllTelemetryAsync();
        Task<Telemetry> GetTelemetryByIdAsync(int id);
        Task<Telemetry> CreateTelemetryAsync(Telemetry telemetry);
        Task UpdateTelemetryAsync(int id, Telemetry telemetry);
        Task DeleteTelemetryAsync(int id);
        Task<bool> TelemetryExistsAsync(int id);
        Task<SavingsResponse> GetSavingsByProjectAsync(int projectId, DateTime startDate, DateTime endDate);
        Task<SavingsResponse> GetSavingsByClientAsync(int clientId, DateTime startDate, DateTime endDate);
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
