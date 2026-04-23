using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly AppDbContext _context;

        public DocumentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentDto>> GetAllDocumentsAsync()
        {
            return await _context.Documents
                .Include(d => d.MedicalRecord)
                    .ThenInclude(m => m.Patient)
                .Select(d => new DocumentDto
                {
                    IdDocument = d.IdDocument,
                    TitleDocument = d.TitleDocument,
                    DescriptionDocument = d.DescriptionDocument,
                    AttachmentDocument = d.AttachmentDocument,
                    DateDocument = d.DateDocument,
                    IdMedicalRecord = d.IdMedicalRecord,
                    PatientFullName = d.MedicalRecord != null && d.MedicalRecord.Patient != null
                        ? $"{d.MedicalRecord.Patient.Firstname} {d.MedicalRecord.Patient.Lastname}"
                        : null
                })
                .OrderByDescending(d => d.DateDocument)
                .ToListAsync();
        }

        public async Task<DocumentDto?> GetDocumentByIdAsync(int id)
        {
            return await _context.Documents
                .Where(d => d.IdDocument == id)
                .Include(d => d.MedicalRecord)
                    .ThenInclude(m => m.Patient)
                .Select(d => new DocumentDto
                {
                    IdDocument = d.IdDocument,
                    TitleDocument = d.TitleDocument,
                    DescriptionDocument = d.DescriptionDocument,
                    AttachmentDocument = d.AttachmentDocument,
                    DateDocument = d.DateDocument,
                    IdMedicalRecord = d.IdMedicalRecord,
                    PatientFullName = d.MedicalRecord != null && d.MedicalRecord.Patient != null
                        ? $"{d.MedicalRecord.Patient.Firstname} {d.MedicalRecord.Patient.Lastname}"
                        : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<DocumentDto>> GetDocumentsByMedicalRecordAsync(int medicalRecordId)
        {
            return await _context.Documents
                .Where(d => d.IdMedicalRecord == medicalRecordId)
                .Include(d => d.MedicalRecord)
                    .ThenInclude(m => m.Patient)
                .Select(d => new DocumentDto
                {
                    IdDocument = d.IdDocument,
                    TitleDocument = d.TitleDocument,
                    DescriptionDocument = d.DescriptionDocument,
                    AttachmentDocument = d.AttachmentDocument,
                    DateDocument = d.DateDocument,
                    IdMedicalRecord = d.IdMedicalRecord,
                    PatientFullName = d.MedicalRecord != null && d.MedicalRecord.Patient != null
                        ? $"{d.MedicalRecord.Patient.Firstname} {d.MedicalRecord.Patient.Lastname}"
                        : null
                })
                .OrderByDescending(d => d.DateDocument)
                .ToListAsync();
        }

        public async Task<DocumentDto> CreateDocumentAsync(CreateDocumentDto dto)
        {
            var document = new Documents
            {
                TitleDocument = dto.TitleDocument,
                DescriptionDocument = dto.DescriptionDocument,
                AttachmentDocument = dto.AttachmentDocument,
                DateDocument = dto.DateDocument ?? DateTime.UtcNow,
                IdMedicalRecord = dto.IdMedicalRecord
            };

            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();

            return (await GetDocumentByIdAsync(document.IdDocument))!;
        }

        public async Task<bool> UpdateDocumentAsync(int id, UpdateDocumentDto dto)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return false;

            if (dto.TitleDocument != null)
                document.TitleDocument = dto.TitleDocument;
            if (dto.DescriptionDocument != null)
                document.DescriptionDocument = dto.DescriptionDocument;
            if (dto.AttachmentDocument != null)
                document.AttachmentDocument = dto.AttachmentDocument;
            if (dto.DateDocument.HasValue)
                document.DateDocument = dto.DateDocument;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return false;

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}