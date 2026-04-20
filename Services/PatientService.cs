using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            return await _context.Patients
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Birthdate = p.Birthdate,
                    CIN = p.CIN,
                    Notebook = p.Notebook,
                    CNSS = p.CNSS,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    Active = p.Active
                })
                .ToListAsync();
        }

        public async Task<List<PatientDto>> GetActivePatientsAsync()
        {
            return await _context.Patients
                .Where(p => p.Active == true)
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Birthdate = p.Birthdate,
                    CIN = p.CIN,
                    Notebook = p.Notebook,
                    CNSS = p.CNSS,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    Active = p.Active
                })
                .ToListAsync();
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                .Where(p => p.IdPatient == id)
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Birthdate = p.Birthdate,
                    CIN = p.CIN,
                    Notebook = p.Notebook,
                    CNSS = p.CNSS,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    Active = p.Active
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto dto)
        {
            var patient = new Patients
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Birthdate = dto.Birthdate,
                CIN = dto.CIN,
                Notebook = dto.Notebook,
                CNSS = dto.CNSS,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Active = dto.Active
            };

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return new PatientDto
            {
                IdPatient = patient.IdPatient,
                Firstname = patient.Firstname,
                Lastname = patient.Lastname,
                Birthdate = patient.Birthdate,
                CIN = patient.CIN,
                Notebook = patient.Notebook,
                CNSS = patient.CNSS,
                Address = patient.Address,
                Phone = patient.Phone,
                Email = patient.Email,
                Active = patient.Active
            };
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatientExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(p => p.IdPatient == id);
        }
    }
}