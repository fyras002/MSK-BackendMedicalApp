namespace MedicalAppBackend.Models
{
    public class Patients
    {
        public int IdPatient { get; set; }
        public int? IdMedicalRecord { get; set; }
        public string Firstname { get; set; } 
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CIN { get; set; }
        public string? Notebook { get; set; }
        public string? CNSS { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }

        public List<Appointments> Appointments { get; set; } = new();
        public MedicalRecords? MedicalRecord { get; set; }=new();
        public List<Consultations> Consultations { get; set; } = new();

    }
}
