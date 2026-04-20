using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatientsAsync();
        Task<List<PatientDto>> GetActivePatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(CreatePatientDto dto);
        Task<bool> DeletePatientAsync(int id);
        Task<bool> PatientExistsAsync(int id);
    }
}