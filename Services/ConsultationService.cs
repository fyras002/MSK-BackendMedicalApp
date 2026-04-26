using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly AppDbContext _context;

        public ConsultationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConsultationDto>> GetAllConsultationsAsync()
        {
            return await _context.Consultations
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.User)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(c => c.MedicalRecord)
                .Select(c => new ConsultationDto
                {
                    IdConsultation = c.IdConsultation,
                    IdPatient = c.IdPatient,
                    PatientFullName = c.Patient != null ? $"{c.Patient.Firstname} {c.Patient.Lastname}" : null,
                    IdDoctor = c.IdDoctor,
                    DoctorFullName = c.Doctor != null && c.Doctor.User != null ? $"{c.Doctor.User.Firstname} {c.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = c.Doctor != null && c.Doctor.Speciality != null ? c.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdMedicalRecord = c.IdMedicalRecord,
                    Tests = c.Tests,
                    Notes = c.Notes,
                    SymptomsList = c.SymptomsList,
                    MedicationsList = c.MedicationsList,
                    MyDateTime = c.MyDateTime
                })
                .OrderByDescending(c => c.MyDateTime)
                .ToListAsync();
        }

        public async Task<ConsultationDto?> GetConsultationByIdAsync(int id)
        {
            return await _context.Consultations
                .Where(c => c.IdConsultation == id)
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.User)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(c => c.MedicalRecord)
                .Select(c => new ConsultationDto
                {
                    IdConsultation = c.IdConsultation,
                    IdPatient = c.IdPatient,
                    PatientFullName = c.Patient != null ? $"{c.Patient.Firstname} {c.Patient.Lastname}" : null,
                    IdDoctor = c.IdDoctor,
                    DoctorFullName = c.Doctor != null && c.Doctor.User != null ? $"{c.Doctor.User.Firstname} {c.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = c.Doctor != null && c.Doctor.Speciality != null ? c.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdMedicalRecord = c.IdMedicalRecord,
                    Tests = c.Tests,
                    Notes = c.Notes,
                    SymptomsList = c.SymptomsList,
                    MedicationsList = c.MedicationsList,
                    MyDateTime = c.MyDateTime
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ConsultationDto>> GetConsultationsByDoctorAsync(int doctorId)
        {
            return await _context.Consultations
                .Where(c => c.IdDoctor == doctorId)
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.User)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(c => c.MedicalRecord)
                .Select(c => new ConsultationDto
                {
                    IdConsultation = c.IdConsultation,
                    IdPatient = c.IdPatient,
                    PatientFullName = c.Patient != null ? $"{c.Patient.Firstname} {c.Patient.Lastname}" : null,
                    IdDoctor = c.IdDoctor,
                    DoctorFullName = c.Doctor != null && c.Doctor.User != null ? $"{c.Doctor.User.Firstname} {c.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = c.Doctor != null && c.Doctor.Speciality != null ? c.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdMedicalRecord = c.IdMedicalRecord,
                    Tests = c.Tests,
                    Notes = c.Notes,
                    SymptomsList = c.SymptomsList,
                    MedicationsList = c.MedicationsList,
                    MyDateTime = c.MyDateTime
                })
                .OrderByDescending(c => c.MyDateTime)
                .ToListAsync();
        }

        public async Task<List<ConsultationDto>> GetConsultationsByPatientAsync(int patientId)
        {
            return await _context.Consultations
                .Where(c => c.IdPatient == patientId)
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.User)
                .Include(c => c.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(c => c.MedicalRecord)
                .Select(c => new ConsultationDto
                {
                    IdConsultation = c.IdConsultation,
                    IdPatient = c.IdPatient,
                    PatientFullName = c.Patient != null ? $"{c.Patient.Firstname} {c.Patient.Lastname}" : null,
                    IdDoctor = c.IdDoctor,
                    DoctorFullName = c.Doctor != null && c.Doctor.User != null ? $"{c.Doctor.User.Firstname} {c.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = c.Doctor != null && c.Doctor.Speciality != null ? c.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdMedicalRecord = c.IdMedicalRecord,
                    Tests = c.Tests,
                    Notes = c.Notes,
                    SymptomsList = c.SymptomsList,
                    MedicationsList = c.MedicationsList,
                    MyDateTime = c.MyDateTime
                })
                .OrderByDescending(c => c.MyDateTime)
                .ToListAsync();
        }

        public async Task<ConsultationDto> CreateConsultationAsync(CreateConsultationDto dto)
        {
            var consultation = new Consultations
            {
                IdPatient = dto.IdPatient,
                IdDoctor = dto.IdDoctor,
                IdMedicalRecord = dto.IdMedicalRecord,
                Tests = dto.Tests,
                Notes = dto.Notes,
                SymptomsList = dto.SymptomsList,
                MedicationsList = dto.MedicationsList,
                MyDateTime = dto.MyDateTime ?? DateTime.UtcNow
            };

            await _context.Consultations.AddAsync(consultation);
            await _context.SaveChangesAsync();

            return (await GetConsultationByIdAsync(consultation.IdConsultation))!;
        }

        public async Task<bool> UpdateConsultationAsync(int id, UpdateConsultationDto dto)
        {
            var consultation = await _context.Consultations.FindAsync(id);
            if (consultation == null)
                return false;

            if (dto.Tests != null) consultation.Tests = dto.Tests;
            if (dto.Notes != null) consultation.Notes = dto.Notes;
            if (dto.SymptomsList != null) consultation.SymptomsList = dto.SymptomsList;
            if (dto.MedicationsList != null) consultation.MedicationsList = dto.MedicationsList;
            if (dto.MyDateTime.HasValue) consultation.MyDateTime = dto.MyDateTime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConsultationAsync(int id)
        {
            var consultation = await _context.Consultations.FindAsync(id);
            if (consultation == null)
                return false;

            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}