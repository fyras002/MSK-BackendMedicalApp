using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctorsAsync();
        Task<List<DoctorDto>> GetAvailableDoctorsAsync();
        Task<DoctorDto?> GetDoctorByIdAsync(int id);
        Task<List<DoctorDto>> GetDoctorsBySpecialityAsync(int specialityId);
        Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto);
        Task<DoctorDto?> UpdateDoctorAsync(int id, UpdateDoctorDto dto);
        Task<bool> DeleteDoctorAsync(int id);
        Task<bool> DoctorExistsAsync(int id);
    }
}