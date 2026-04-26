using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<List<PrescriptionDto>> GetAllPrescriptionsAsync();
        Task<PrescriptionDto?> GetPrescriptionByIdAsync(int id);
        Task<List<PrescriptionDto>> GetPrescriptionsByDocumentAsync(int documentId);
        Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto dto);
        Task<bool> UpdatePrescriptionAsync(int id, UpdatePrescriptionDto dto);
        Task<bool> DeletePrescriptionAsync(int id);
    }
}