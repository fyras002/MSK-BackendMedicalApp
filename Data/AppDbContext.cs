using MedicalAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


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

        
            //hedhi pour ignorer les nulls
            modelBuilder.Entity<Patients>()
                .Navigation(p => p.MedicalRecord)
                .AutoInclude(false);

            modelBuilder.Entity<Patients>()
                .Navigation(p => p.Appointments)
                .AutoInclude(false);

            modelBuilder.Entity<Patients>()
                .Navigation(p => p.Consultations)
                .AutoInclude(false);
            //les relations bin les tables 

            modelBuilder.Entity<Patients>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<MedicalRecords>()
                .HasOne(m => m.Patient)
                .WithOne(p => p.MedicalRecord)
                .HasForeignKey<MedicalRecords>(m => m.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);
            // Doctor -> User (One-to-One)
            modelBuilder.Entity<Doctors>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId);
            // Doctor -> Speciality (Many-to-One)
            modelBuilder.Entity<Doctors>()
                .HasOne(d => d.Speciality)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialityId);
            // Appointment -> InsuranceCompany (Many-to-One)
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.InsuranceCompany)
                .WithMany(i => i.Appointments)
                .HasForeignKey(a => a.IdCompany);
            // Appointment -> Patient
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.IdPatient);
            // Appointment -> Doctor
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.IdDoctor);
            modelBuilder.Entity<Documents>()
                .HasOne(d => d.MedicalRecord)
                .WithMany(m => m.Documents)
                .HasForeignKey(d => d.IdMedicalRecord);
            modelBuilder.Entity<Consultations>()
                .HasOne(c => c.Patient)
                .WithMany(p => p.Consultations)
                .HasForeignKey(c => c.IdPatient);

            modelBuilder.Entity<Consultations>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Consultations)
                .HasForeignKey(c => c.IdDoctor);

            modelBuilder.Entity<Consultations>()
                .HasOne(c => c.MedicalRecord)
                .WithMany()
                .HasForeignKey(c => c.IdMedicalRecord);
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Document)
                .WithMany()
                .HasForeignKey(p => p.IdDocument);

        }
    }
}