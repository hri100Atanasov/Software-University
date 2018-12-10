using Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        { }

        public HospitalContext(DbContextOptionsBuilder options)
        { }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new VisitationConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnoseConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new PatientMedicamentConfig());
        }
    }
}
