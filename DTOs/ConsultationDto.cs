namespace MedicalAppBackend.DTOs
{
    public class ConsultationDto
    {
        public int IdConsultation { get; set; }
        public int? IdPatient { get; set; }
        public string? PatientFullName { get; set; }
        public int? IdDoctor { get; set; }
        public string? DoctorFullName { get; set; }
        public string? DoctorSpeciality { get; set; }
        public int? IdMedicalRecord { get; set; }
        public string? Tests { get; set; }
        public string? Notes { get; set; }
        public string? SymptomsList { get; set; }
        public string? MedicationsList { get; set; }
        public DateTime? MyDateTime { get; set; }
    }

    public class CreateConsultationDto
    {
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdMedicalRecord { get; set; }
        public string? Tests { get; set; }
        public string? Notes { get; set; }
        public string? SymptomsList { get; set; }
        public string? MedicationsList { get; set; }
        public DateTime? MyDateTime { get; set; }
    }

    public class UpdateConsultationDto
    {
        public string? Tests { get; set; }
        public string? Notes { get; set; }
        public string? SymptomsList { get; set; }
        public string? MedicationsList { get; set; }
        public DateTime? MyDateTime { get; set; }
    }
}