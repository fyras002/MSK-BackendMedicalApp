namespace MedicalAppBackend.DTOs
{
    public class PrescriptionDto
    {
        public int IdPerscription { get; set; }
        public DateTime? Date { get; set; }
        public string? DocName { get; set; }
        public string? MedicationList { get; set; }
        public int? IdDocument { get; set; }
        public string? DocumentTitle { get; set; }
    }

    public class CreatePrescriptionDto
    {
        public DateTime? Date { get; set; }
        public string? DocName { get; set; }
        public string? MedicationList { get; set; }
        public int? IdDocument { get; set; }
    }

    public class UpdatePrescriptionDto
    {
        public DateTime? Date { get; set; }
        public string? DocName { get; set; }
        public string? MedicationList { get; set; }
        public int? IdDocument { get; set; }
    }
}