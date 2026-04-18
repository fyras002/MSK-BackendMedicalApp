using System.Numerics;
using MedicalAppBackend.Enums;

namespace MedicalAppBackend.Models
{
    public class Specialities
    {
        public int Id { get; set; }
        public SpecialityEnum SpecialityName { get; set; }
        public string? Description { get; set; }

        public List<Doctors> Doctors { get; set; } = new();
    }
}
