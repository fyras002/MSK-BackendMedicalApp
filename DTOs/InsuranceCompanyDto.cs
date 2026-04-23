namespace MedicalAppBackend.DTOs
{
    public class InsuranceCompanyDto
    {
        public int IdCompany { get; set; }
        public string? CompanyName { get; set; }
        public string? Type { get; set; }
        public DateTime? ValidDate { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public List<AppointmentSummaryDto> Appointments { get; set; } = new();
    }

    public class AppointmentSummaryDto
    {
        public int IdAppointment { get; set; }
        public string? PatientName { get; set; }
        public DateTime? DateTimeAppointment { get; set; }
        public string? Reason { get; set; }
    }

    public class CreateInsuranceCompanyDto
    {
        public string? CompanyName { get; set; }
        public string? Type { get; set; }
        public DateTime? ValidDate { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
    }

    public class UpdateInsuranceCompanyDto
    {
        public string? CompanyName { get; set; }
        public string? Type { get; set; }
        public DateTime? ValidDate { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
    }
}