using DentaPix_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentaPix_Clinic.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient_Appointment>().HasKey(pa => new
        {

            pa.PatientId,
            pa.AppointmentId
        });

        modelBuilder.Entity<Patient_Appointment>().HasOne(a => a.Appointment).WithMany(pa => pa.Patients_Appointments).HasForeignKey(a => a.AppointmentId);
        modelBuilder.Entity<Patient_Appointment>().HasOne(a => a.Patient).WithMany(pa => pa.Patients_Appointments).HasForeignKey(a => a.PatientId);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient_Appointment> Patients_Appointments { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Payment> Payments { get; set; }


}
