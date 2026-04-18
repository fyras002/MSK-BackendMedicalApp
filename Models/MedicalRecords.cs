using System.Reflection.Metadata;

namespace MedicalAppBackend.Models
{
    public class MedicalRecords
    {
        public int IdMedicalRecord { get; set; }

        public int? IdPatient { get; set; }

        public string? BloodDraw { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? MedicalCheckup { get; set; }
        public string? HereditaryDiseases { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? Status { get; set; }

        public List<Documents> Documents { get; set; } = new();
    }
}
