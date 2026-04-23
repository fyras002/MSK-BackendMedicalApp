using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface ISpecialityService
    {
        Task<List<SpecialityDto>> GetAllSpecialitiesAsync();
        Task<SpecialityDto?> GetSpecialityByIdAsync(int id);
        Task<SpecialityDto> CreateSpecialityAsync(CreateSpecialityDto dto);
        Task<bool> UpdateSpecialityAsync(int id, UpdateSpecialityDto dto);
        Task<bool> DeleteSpecialityAsync(int id);
        Task<bool> HasDoctorsAsync(int id);
    }
}