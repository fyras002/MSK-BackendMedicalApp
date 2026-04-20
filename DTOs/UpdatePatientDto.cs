using System.ComponentModel.DataAnnotations;

namespace MedicalAppBackend.DTOs
{
    public class UpdatePatientDto
    {
        
        [MaxLength(100)]
        public string? Firstname { get; set; }

        [MaxLength(100)]
        public string? Lastname { get; set; }

        public DateTime? Birthdate { get; set; }

        [MaxLength(50)]
        public string? CIN { get; set; }

        [MaxLength(50)]
        public string? Notebook { get; set; }

        [MaxLength(50)]
        public string? CNSS { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        public bool? Active { get; set; }
    }
}