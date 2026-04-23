using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly AppDbContext _context;

        public MedicalRecordService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicalRecordDto>> GetAllMedicalRecordsAsync()
        {
            return await _context.MedicalRecords
                .Include(m => m.Patient)
                .Include(m => m.Documents)
                .Select(m => new MedicalRecordDto
                {
                    IdMedicalRecord = m.IdMedicalRecord,
                    IdPatient = m.IdPatient,
                    PatientFullName = m.Patient != null ? $"{m.Patient.Firstname} {m.Patient.Lastname}" : null,
                    BloodDraw = m.BloodDraw,
                    Height = m.Height,
                    Weight = m.Weight,
                    MedicalCheckup = m.MedicalCheckup,
                    HereditaryDiseases = m.HereditaryDiseases,
                    ChronicDiseases = m.ChronicDiseases,
                    Status = m.Status,
                    Documents = m.Documents.Select(d => new DocumentSummaryDto
                    {
                        IdDocument = d.IdDocument,
                        TitleDocument = d.TitleDocument,
                        DateDocument = d.DateDocument
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int id)
        {
            return await _context.MedicalRecords
                .Where(m => m.IdMedicalRecord == id)
                .Include(m => m.Patient)
                .Include(m => m.Documents)
                .Select(m => new MedicalRecordDto
                {
                    IdMedicalRecord = m.IdMedicalRecord,
                    IdPatient = m.IdPatient,
                    PatientFullName = m.Patient != null ? $"{m.Patient.Firstname} {m.Patient.Lastname}" : null,
                    BloodDraw = m.BloodDraw,
                    Height = m.Height,
                    Weight = m.Weight,
                    MedicalCheckup = m.MedicalCheckup,
                    HereditaryDiseases = m.HereditaryDiseases,
                    ChronicDiseases = m.ChronicDiseases,
                    Status = m.Status,
                    Documents = m.Documents.Select(d => new DocumentSummaryDto
                    {
                        IdDocument = d.IdDocument,
                        TitleDocument = d.TitleDocument,
                        DateDocument = d.DateDocument
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MedicalRecordDto?> GetMedicalRecordByPatientIdAsync(int patientId)
        {
            return await _context.MedicalRecords
                .Where(m => m.IdPatient == patientId)
                .Include(m => m.Patient)
                .Include(m => m.Documents)
                .Select(m => new MedicalRecordDto
                {
                    IdMedicalRecord = m.IdMedicalRecord,
                    IdPatient = m.IdPatient,
                    PatientFullName = m.Patient != null ? $"{m.Patient.Firstname} {m.Patient.Lastname}" : null,
                    BloodDraw = m.BloodDraw,
                    Height = m.Height,
                    Weight = m.Weight,
                    MedicalCheckup = m.MedicalCheckup,
                    HereditaryDiseases = m.HereditaryDiseases,
                    ChronicDiseases = m.ChronicDiseases,
                    Status = m.Status,
                    Documents = m.Documents.Select(d => new DocumentSummaryDto
                    {
                        IdDocument = d.IdDocument,
                        TitleDocument = d.TitleDocument,
                        DateDocument = d.DateDocument
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto dto)
        {
            var medicalRecord = new MedicalRecords
            {
                IdPatient = dto.IdPatient,
                BloodDraw = dto.BloodDraw,
                Height = dto.Height,
                Weight = dto.Weight,
                MedicalCheckup = dto.MedicalCheckup,
                HereditaryDiseases = dto.HereditaryDiseases,
                ChronicDiseases = dto.ChronicDiseases,
                Status = dto.Status ?? "Active"
            };

            await _context.MedicalRecords.AddAsync(medicalRecord);
            await _context.SaveChangesAsync();

            return (await GetMedicalRecordByIdAsync(medicalRecord.IdMedicalRecord))!;
        }

        public async Task<bool> UpdateMedicalRecordAsync(int id, UpdateMedicalRecordDto dto)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
                return false;

            if (dto.BloodDraw != null)
                medicalRecord.BloodDraw = dto.BloodDraw;
            if (dto.Height != null)
                medicalRecord.Height = dto.Height;
            if (dto.Weight != null)
                medicalRecord.Weight = dto.Weight;
            if (dto.MedicalCheckup != null)
                medicalRecord.MedicalCheckup = dto.MedicalCheckup;
            if (dto.HereditaryDiseases != null)
                medicalRecord.HereditaryDiseases = dto.HereditaryDiseases;
            if (dto.ChronicDiseases != null)
                medicalRecord.ChronicDiseases = dto.ChronicDiseases;
            if (dto.Status != null)
                medicalRecord.Status = dto.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMedicalRecordAsync(int id)
        {
            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.Documents)
                .FirstOrDefaultAsync(m => m.IdMedicalRecord == id);

            if (medicalRecord == null)
                return false;

            _context.Documents.RemoveRange(medicalRecord.Documents);
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatientHasMedicalRecordAsync(int patientId)
        {
            return await _context.MedicalRecords.AnyAsync(m => m.IdPatient == patientId);
        }
    }
}