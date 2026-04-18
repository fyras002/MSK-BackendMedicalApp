namespace MedicalAppBackend.Models
{
    public class Documents
    {
        public int IdDocument { get; set; }
        public string? TitleDocument { get; set; }
        public string? DescriptionDocument { get; set; }
        public string? AttachmentDocument { get; set; }
        public DateTime? DateDocument { get; set; }

        public int? IdMedicalRecord { get; set; }
        public MedicalRecords? MedicalRecord { get; set; }
    }
}
