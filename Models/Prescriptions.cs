using System.Reflection.Metadata;

namespace MedicalAppBackend.Models
{
    public class Prescription
    {
        public int IdPerscription { get; set; }
        public DateTime? Date { get; set; }
        public string? DocName { get; set; }
        public string? MedicationList { get; set; }

        public int? IdDocument { get; set; }
        public Documents? Document { get; set; }
    }
}
