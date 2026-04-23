using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<List<MedicalRecordDto>> GetAllMedicalRecordsAsync();
        Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int id);
        Task<MedicalRecordDto?> GetMedicalRecordByPatientIdAsync(int patientId);
        Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto dto);
        Task<bool> UpdateMedicalRecordAsync(int id, UpdateMedicalRecordDto dto);
        Task<bool> DeleteMedicalRecordAsync(int id);
        Task<bool> PatientHasMedicalRecordAsync(int patientId);
    }
}