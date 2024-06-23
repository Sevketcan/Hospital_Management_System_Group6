using Microsoft.EntityFrameworkCore;

using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Admin
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Username = "admin",
                Password = "admin123" // Use a hashed password in a real application
            });

            // Seed data for Hospitals
            modelBuilder.Entity<Hospital>().HasData(
                new Hospital { Id = 1, Name = "Hospital A", Email = "contact@hospitala.com", Password = "pass123", City = "City A", Phone = "123456789" },
                new Hospital { Id = 2, Name = "Hospital B", Email = "contact@hospitalb.com", Password = "pass123", City = "City B", Phone = "987654321" }
            );

            // Seed data for Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Doctor A", Surname = "Surname A", Email = "doctora@hospitala.com", Password = "pass123", Phone = "123456789", Branch = "Cardiology", HospitalId = 1 },
                new Doctor { Id = 2, Name = "Doctor B", Surname = "Surname B", Email = "doctorb@hospitala.com", Password = "pass123", Phone = "987654321", Branch = "Neurology", HospitalId = 1 },
                new Doctor { Id = 3, Name = "Doctor C", Surname = "Surname C", Email = "doctorc@hospitalb.com", Password = "pass123", Phone = "123456789", Branch = "Pediatrics", HospitalId = 2 }
            );

            // Seed data for Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Patient A", Surname = "Surname A", Tc = "12345678901", Email = "patienta@mail.com", Password = "pass123", Phone = "123456789", Address = "Address A" },
                new Patient { Id = 2, Name = "Patient B", Surname = "Surname B", Tc = "98765432109", Email = "patientb@mail.com", Password = "pass123", Phone = "987654321", Address = "Address B" }
            );

            // Seed data for Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, Diagnosis = "Flu", Time = DateTime.Now, DoctorId = 1, PatientId = 1 },
                new Appointment { Id = 2, Diagnosis = "Cold", Time = DateTime.Now, DoctorId = 2, PatientId = 2 }
            );

            // Seed data for Prescriptions
            modelBuilder.Entity<Prescriptions>().HasData(
                new Prescriptions { Id = 1, Medicine = "Medicine A", PatientId = 1, AppointmentId = 1 },
                new Prescriptions { Id = 2, Medicine = "Medicine B", PatientId = 2, AppointmentId = 2 }
            );

            // Configure relationships
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Hospital)
                .WithMany(h => h.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescriptions>()
                .HasOne(p => p.Patient)
                .WithMany(pat => pat.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Prescriptions>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
