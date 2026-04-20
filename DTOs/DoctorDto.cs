namespace MedicalAppBackend.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;  
        public string? Email { get; set; }                   
        public string? SpecialityName { get; set; }           
        public string? LicenseNumber { get; set; }
        public string? Biography { get; set; }
        public int? YearsOfExperience { get; set; }
        public bool? IsAvailable { get; set; }
    }
}