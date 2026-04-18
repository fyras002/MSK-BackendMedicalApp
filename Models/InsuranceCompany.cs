namespace MedicalAppBackend.Models
{
    public class InsuranceCompany
    {
        public int IdCompany { get; set; }
        public string? CompanyName { get; set; }
        public string? Type { get; set; }
        public DateTime? ValidDate { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public List<Appointments> Appointments { get; set; } = new();
    }
}
