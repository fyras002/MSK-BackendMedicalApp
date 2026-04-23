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
                .Include(p => p.User)
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    UserId = p.UserId,
                    Username = p.User != null ? p.User.Username : null,
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
                .Include(p => p.User)
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    UserId = p.UserId,
                    Username = p.User != null ? p.User.Username : null,
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
                .Include(p => p.User)
                .Select(p => new PatientDto
                {
                    IdPatient = p.IdPatient,
                    UserId = p.UserId,
                    Username = p.User != null ? p.User.Username : null,
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
                UserId = dto.UserId,
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

            return (await GetPatientByIdAsync(patient.IdPatient))!;
        }

        public async Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return null;

            if (dto.UserId.HasValue)
                patient.UserId = dto.UserId;
            if (dto.Firstname != null)
                patient.Firstname = dto.Firstname;
            if (dto.Lastname != null)
                patient.Lastname = dto.Lastname;
            if (dto.Birthdate.HasValue)
                patient.Birthdate = dto.Birthdate;
            if (dto.CIN != null)
                patient.CIN = dto.CIN;
            if (dto.Notebook != null)
                patient.Notebook = dto.Notebook;
            if (dto.CNSS != null)
                patient.CNSS = dto.CNSS;
            if (dto.Address != null)
                patient.Address = dto.Address;
            if (dto.Phone != null)
                patient.Phone = dto.Phone;
            if (dto.Email != null)
                patient.Email = dto.Email;
            if (dto.Active.HasValue)
                patient.Active = dto.Active;

            await _context.SaveChangesAsync();
            return await GetPatientByIdAsync(id);
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