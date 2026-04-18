using MedicalAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using MedicalAppBackend.Models;

namespace MedicalAppBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Relationships> Relationships { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<DiseaseList> DiseaseLists { get; set; }
        public DbSet<Consultations> Consultations { get; set; }
        public DbSet<Specialities> Specialities { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<MedicationList> MedicationLists { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Chats> Chats { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary Keys
            modelBuilder.Entity<Patients>()
                .HasKey(p => p.IdPatient);

            modelBuilder.Entity<Appointments>()
                .HasKey(a => a.IdAppointment);

            modelBuilder.Entity<Relationships>()
                .HasKey(r => r.IdRelationships);

            modelBuilder.Entity<MedicalRecords>()
                .HasKey(m => m.IdMedicalRecord);

            modelBuilder.Entity<Documents>()
                .HasKey(d => d.IdDocument);

            modelBuilder.Entity<Prescription>()
                .HasKey(p => p.IdPerscription);

            modelBuilder.Entity<DiseaseList>()
                .HasKey(d => d.IdDiseaseList);

            modelBuilder.Entity<Consultations>()
                .HasKey(c => c.IdConsultation);

            modelBuilder.Entity<MedicationList>()
                .HasKey(m => m.IdMedication);

            modelBuilder.Entity<InsuranceCompany>()
                .HasKey(i => i.IdCompany);

            modelBuilder.Entity<Chats>()
                .HasKey(c => c.IdChat);

            modelBuilder.Entity<ChatMessages>()
                .HasKey(cm => cm.IdChatMessage);

            
        }
    }
}