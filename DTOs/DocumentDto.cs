namespace MedicalAppBackend.DTOs
{
    public class DocumentDto
    {
        public int IdDocument { get; set; }
        public string? TitleDocument { get; set; }
        public string? DescriptionDocument { get; set; }
        public string? AttachmentDocument { get; set; }
        public DateTime? DateDocument { get; set; }
        public int? IdMedicalRecord { get; set; }
        public string? PatientFullName { get; set; }
    }

    public class CreateDocumentDto
    {
        public string? TitleDocument { get; set; }
        public string? DescriptionDocument { get; set; }
        public string? AttachmentDocument { get; set; }
        public DateTime? DateDocument { get; set; }
        public int? IdMedicalRecord { get; set; }
    }

    public class UpdateDocumentDto
    {
        public string? TitleDocument { get; set; }
        public string? DescriptionDocument { get; set; }
        public string? AttachmentDocument { get; set; }
        public DateTime? DateDocument { get; set; }
    }
}