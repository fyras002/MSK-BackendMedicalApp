namespace MedicalAppBackend.DTOs
{
    public class AppointmentDto
    {
        public int IdAppointment { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientGender { get; set; }
        public string? Symptoms { get; set; }
        public string? Reason { get; set; }
        public DateTime? DateTimeAppointment { get; set; }
        public bool? IsNewPatient { get; set; }
        public int? IdPatient { get; set; }
        public string? PatientFullName { get; set; }
        public int? IdDoctor { get; set; }
        public string? DoctorFullName { get; set; }
        public string? DoctorSpeciality { get; set; }
        public int? IdCompany { get; set; }
        public string? InsuranceCompanyName { get; set; }
    }

    public class CreateAppointmentDto
    {
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientGender { get; set; }
        public string? Symptoms { get; set; }
        public string? Reason { get; set; }
        public DateTime? DateTimeAppointment { get; set; }
        public bool? IsNewPatient { get; set; }
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdCompany { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientGender { get; set; }
        public string? Symptoms { get; set; }
        public string? Reason { get; set; }
        public DateTime? DateTimeAppointment { get; set; }
        public bool? IsNewPatient { get; set; }
        public int? IdPatient { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdCompany { get; set; }
    }
}