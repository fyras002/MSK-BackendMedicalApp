using System.ComponentModel.DataAnnotations;

namespace MedicalAppBackend.Models
{
    public class Patients
    {
        [Key]
        public int IdPatient { get; set; }

        public int? UserId { get; set; }
        public Users? User { get; set; }

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public string? CIN { get; set; }
        public string? Notebook { get; set; }
        public string? CNSS { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }

        public MedicalRecords? MedicalRecord { get; set; }
        public List<Appointments> Appointments { get; set; } = new();
        public List<Consultations> Consultations { get; set; } = new();
    }
}