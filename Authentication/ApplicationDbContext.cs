using Microsoft.EntityFrameworkCore;
using Nwu_Tech_Trends.Models;

namespace JWTAuthentication.Authentication
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobTelemetry> JobTelemetries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTelemetry>(entity =>
            {
                entity.ToTable("JobTelemetry", "Telemetry");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalInfo).IsUnicode(false);

                entity.Property(e => e.BusinessFunction).IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExcludeFromTimeSaving).HasDefaultValueSql("((0))");

                entity.Property(e => e.Geography).IsUnicode(false);

                entity.Property(e => e.JobId)
                    .IsUnicode(false)
                    .HasColumnName("JobID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.QueueId)
                    .IsUnicode(false)
                    .HasColumnName("QueueID");

                entity.Property(e => e.StepDescription).IsUnicode(false);

                entity.Property(e => e.UniqueReference).IsUnicode(false);

                entity.Property(e => e.UniqueReferenceType).IsUnicode(false);
            });
        }
    }
}
