namespace MedicalAppBackend.DTOs
{
    public class PatientDto
    {
        public int IdPatient { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
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
    }
}