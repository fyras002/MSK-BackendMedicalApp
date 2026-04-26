using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IConsultationService
    {
        Task<List<ConsultationDto>> GetAllConsultationsAsync();
        Task<ConsultationDto?> GetConsultationByIdAsync(int id);
        Task<List<ConsultationDto>> GetConsultationsByDoctorAsync(int doctorId);
        Task<List<ConsultationDto>> GetConsultationsByPatientAsync(int patientId);
        Task<ConsultationDto> CreateConsultationAsync(CreateConsultationDto dto);
        Task<bool> UpdateConsultationAsync(int id, UpdateConsultationDto dto);
        Task<bool> DeleteConsultationAsync(int id);
    }
}