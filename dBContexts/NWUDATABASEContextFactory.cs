using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Nwu_Tech_Trends.dBContexts;
using System.IO;

namespace Nwu_Tech_Trends.Models
{
    public class NWUDATABASEContextFactory : IDesignTimeDbContextFactory<NWUDATABASEContext>
    {
        public NWUDATABASEContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ConnStr");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'ConnStr' is not found or is null.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<NWUDATABASEContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NWUDATABASEContext(optionsBuilder.Options);
        }
    }
}
