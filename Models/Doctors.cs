namespace MedicalAppBackend.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }

        public int? SpecialityId { get; set; }
        public Specialities? Speciality { get; set; }

        public string? LicenseNumber { get; set; }
        public string? Biography { get; set; }
        public int? YearsOfExperience { get; set; }
        public bool? IsAvailable { get; set; }

        public List<Consultations> Consultations { get; set; } = new();
        public List<Appointments> Appointments { get; set; } = new();
    }
}
