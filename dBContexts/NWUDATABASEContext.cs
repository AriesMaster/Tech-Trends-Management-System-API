using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nwu_Tech_Trends.Models;
using JWTAuthentication.Authentication;

namespace Nwu_Tech_Trends.dBContexts
{
    public partial class NWUDATABASEContext : IdentityDbContext<ApplicationUser>
    {
        public NWUDATABASEContext(DbContextOptions<NWUDATABASEContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<JobTelemetry> JobTelemetries { get; set; } = null!;
        public virtual DbSet<Process> Processes { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to configure Identity tables
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "Config");

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateOnboarded).HasColumnType("datetime");
            });

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

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process", "Config");

                entity.Property(e => e.ProcessId)
                    .HasColumnName("ProcessID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Platform).IsUnicode(false);

                entity.Property(e => e.ProcessConfigUrl)
                    .IsUnicode(false)
                    .HasColumnName("ProcessConfigURL");

                entity.Property(e => e.ProcessName).IsUnicode(false);

                entity.Property(e => e.ProcessType).IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ReportUrl)
                    .IsUnicode(false)
                    .HasColumnName("ReportURL");

                entity.Property(e => e.Submitter).IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "Config");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ProjectCreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
