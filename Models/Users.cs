using System.Data;

namespace MedicalAppBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Photo { get; set; }

        public int? RoleId { get; set; }  
        public Roles? Role { get; set; }   
    }
}
