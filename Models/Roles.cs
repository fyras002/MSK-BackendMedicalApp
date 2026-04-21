using MedicalAppBackend.Enums;
namespace MedicalAppBackend.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public RolesEnum TitleName { get; set; }
        public string? Description { get; set; }
    }
}
