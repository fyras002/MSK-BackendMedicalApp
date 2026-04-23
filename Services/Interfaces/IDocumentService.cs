using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<List<DocumentDto>> GetAllDocumentsAsync();
        Task<DocumentDto?> GetDocumentByIdAsync(int id);
        Task<List<DocumentDto>> GetDocumentsByMedicalRecordAsync(int medicalRecordId);
        Task<DocumentDto> CreateDocumentAsync(CreateDocumentDto dto);
        Task<bool> UpdateDocumentAsync(int id, UpdateDocumentDto dto);
        Task<bool> DeleteDocumentAsync(int id);
    }
}