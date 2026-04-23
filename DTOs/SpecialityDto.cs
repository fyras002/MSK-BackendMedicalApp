namespace MedicalAppBackend.DTOs
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<DoctorSummaryDto> Doctors { get; set; } = new();
    }

    public class DoctorSummaryDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? LicenseNumber { get; set; }
        public int? YearsOfExperience { get; set; }
        public bool? IsAvailable { get; set; }
    }

    public class CreateSpecialityDto
    {
        public int SpecialityName { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateSpecialityDto
    {
        public int? SpecialityName { get; set; }
        public string? Description { get; set; }
    }
}
