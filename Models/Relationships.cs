namespace MedicalAppBackend.Models
{
    public class Relationships
    {
        public int IdRelationships { get; set; }

        public int? IdPatient1 { get; set; }
        public Patients? Patient1 { get; set; }

        public int? IdPatient2 { get; set; }
        public Patients? Patient2 { get; set; }

        public string? TitleRelationships { get; set; }  
        public string? NotesRelationships { get; set; }
    }
}
