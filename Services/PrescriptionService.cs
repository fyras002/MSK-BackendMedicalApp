using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly AppDbContext _context;

        public PrescriptionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions
                .Include(p => p.Document)
                .Select(p => new PrescriptionDto
                {
                    IdPerscription = p.IdPerscription,
                    Date = p.Date,
                    DocName = p.DocName,
                    MedicationList = p.MedicationList,
                    IdDocument = p.IdDocument,
                    DocumentTitle = p.Document != null ? p.Document.TitleDocument : null
                })
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public async Task<PrescriptionDto?> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions
                .Where(p => p.IdPerscription == id)
                .Include(p => p.Document)
                .Select(p => new PrescriptionDto
                {
                    IdPerscription = p.IdPerscription,
                    Date = p.Date,
                    DocName = p.DocName,
                    MedicationList = p.MedicationList,
                    IdDocument = p.IdDocument,
                    DocumentTitle = p.Document != null ? p.Document.TitleDocument : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<PrescriptionDto>> GetPrescriptionsByDocumentAsync(int documentId)
        {
            return await _context.Prescriptions
                .Where(p => p.IdDocument == documentId)
                .Include(p => p.Document)
                .Select(p => new PrescriptionDto
                {
                    IdPerscription = p.IdPerscription,
                    Date = p.Date,
                    DocName = p.DocName,
                    MedicationList = p.MedicationList,
                    IdDocument = p.IdDocument,
                    DocumentTitle = p.Document != null ? p.Document.TitleDocument : null
                })
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public async Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                Date = dto.Date ?? DateTime.UtcNow,
                DocName = dto.DocName,
                MedicationList = dto.MedicationList,
                IdDocument = dto.IdDocument
            };

            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();

            return (await GetPrescriptionByIdAsync(prescription.IdPerscription))!;
        }

        public async Task<bool> UpdatePrescriptionAsync(int id, UpdatePrescriptionDto dto)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
                return false;

            if (dto.Date.HasValue) prescription.Date = dto.Date;
            if (dto.DocName != null) prescription.DocName = dto.DocName;
            if (dto.MedicationList != null) prescription.MedicationList = dto.MedicationList;
            if (dto.IdDocument.HasValue) prescription.IdDocument = dto.IdDocument;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePrescriptionAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
                return false;

            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}