namespace MedicalAppBackend.Models
{
    public class MedicationList
    {
        public int IdMedication { get; set; }
        public string? TitleMedication { get; set; }
        public string? DescriptionMedication { get; set; }
        public string? DaysToTaken { get; set; }
        public string? AgeRange { get; set; }
        public string? SymptomesList { get; set; }
        public string? Shouldnotbetaken { get; set; }
        public string? HowToTake { get; set; }
    }
}
