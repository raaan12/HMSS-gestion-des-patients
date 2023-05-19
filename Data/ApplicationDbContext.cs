using HMSS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMSS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // configure relationships
            modelBuilder.Entity<Doctor>()
                .HasOne(l => l.departement)
                .WithMany(c => c.doctors)
                .HasForeignKey(l => l.Department_id);
            modelBuilder.Entity<Patient>()
                .HasOne(l => l.doctor)
                .WithMany(a => a.patients)
                .HasForeignKey(l => l.Doctor_id);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Departement>? Departments { get; set; }
    }
}
