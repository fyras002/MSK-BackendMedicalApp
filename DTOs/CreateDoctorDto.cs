using System.ComponentModel.DataAnnotations;

namespace MedicalAppBackend.DTOs
{
    public class CreateDoctorDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicenseNumber { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Biography { get; set; }

        public int? YearsOfExperience { get; set; }
        public bool? IsAvailable { get; set; }
    }
}