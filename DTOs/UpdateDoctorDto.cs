using System.ComponentModel.DataAnnotations;

namespace MedicalAppBackend.DTOs
{
    public class UpdateDoctorDto
    {
        public int? SpecialityId { get; set; }

        [MaxLength(50)]
        public string? LicenseNumber { get; set; }

        [MaxLength(500)]
        public string? Biography { get; set; }

        public int? YearsOfExperience { get; set; }
        public bool? IsAvailable { get; set; }
    }
}