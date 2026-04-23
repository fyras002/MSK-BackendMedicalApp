namespace MedicalAppBackend.DTOs
{
    public class MedicalRecordDto
    {
        public int IdMedicalRecord { get; set; }
        public int? IdPatient { get; set; }
        public string? PatientFullName { get; set; }
        public string? BloodDraw { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? MedicalCheckup { get; set; }
        public string? HereditaryDiseases { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? Status { get; set; }
        public List<DocumentSummaryDto> Documents { get; set; } = new();
    }

    public class DocumentSummaryDto
    {
        public int IdDocument { get; set; }
        public string? TitleDocument { get; set; }
        public DateTime? DateDocument { get; set; }
    }

    public class CreateMedicalRecordDto
    {
        public int? IdPatient { get; set; }
        public string? BloodDraw { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? MedicalCheckup { get; set; }
        public string? HereditaryDiseases { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateMedicalRecordDto
    {
        public string? BloodDraw { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? MedicalCheckup { get; set; }
        public string? HereditaryDiseases { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? Status { get; set; }
    }
}