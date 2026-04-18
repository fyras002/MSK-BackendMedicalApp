using System.Numerics;

namespace MedicalAppBackend.Models
{
    public class Consultations
    {
        public int IdConsultation { get; set; }

        public int? IdPatient { get; set; }
        public Patients? Patient { get; set; }

        public int? IdDoctor { get; set; }
        public Doctors? Doctor { get; set; }

        public int? IdMedicalRecord { get; set; }
        public MedicalRecords? MedicalRecord { get; set; }

        public string? Tests { get; set; }
        public string? Notes { get; set; }
        public string? SymptomsList { get; set; }
        public string? MedicationsList { get; set; }
        public DateTime? MyDateTime { get; set; }
    }
}
