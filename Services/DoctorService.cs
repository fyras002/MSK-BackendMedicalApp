using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Speciality)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                    Email = d.User != null ? d.User.Email : null,
                    SpecialityName = d.Speciality != null ? d.Speciality.SpecialityName.ToString() : null,
                    LicenseNumber = d.LicenseNumber,
                    Biography = d.Biography,
                    YearsOfExperience = d.YearsOfExperience,
                    IsAvailable = d.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<List<DoctorDto>> GetAvailableDoctorsAsync()
        {
            return await _context.Doctors
                .Where(d => d.IsAvailable == true)
                .Include(d => d.User)
                .Include(d => d.Speciality)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                    Email = d.User != null ? d.User.Email : null,
                    SpecialityName = d.Speciality != null ? d.Speciality.SpecialityName.ToString() : null,
                    LicenseNumber = d.LicenseNumber,
                    Biography = d.Biography,
                    YearsOfExperience = d.YearsOfExperience,
                    IsAvailable = d.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
                .Where(d => d.Id == id)
                .Include(d => d.User)
                .Include(d => d.Speciality)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                    Email = d.User != null ? d.User.Email : null,
                    SpecialityName = d.Speciality != null ? d.Speciality.SpecialityName.ToString() : null,
                    LicenseNumber = d.LicenseNumber,
                    Biography = d.Biography,
                    YearsOfExperience = d.YearsOfExperience,
                    IsAvailable = d.IsAvailable
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<DoctorDto>> GetDoctorsBySpecialityAsync(int specialityId)
        {
            return await _context.Doctors
                .Where(d => d.SpecialityId == specialityId)
                .Include(d => d.User)
                .Include(d => d.Speciality)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                    Email = d.User != null ? d.User.Email : null,
                    SpecialityName = d.Speciality != null ? d.Speciality.SpecialityName.ToString() : null,
                    LicenseNumber = d.LicenseNumber,
                    Biography = d.Biography,
                    YearsOfExperience = d.YearsOfExperience,
                    IsAvailable = d.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto)
        {
            var doctor = new Doctors
            {
                UserId = dto.UserId,
                SpecialityId = dto.SpecialityId,
                LicenseNumber = dto.LicenseNumber,
                Biography = dto.Biography,
                YearsOfExperience = dto.YearsOfExperience,
                IsAvailable = dto.IsAvailable ?? true
            };

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return await GetDoctorByIdAsync(doctor.Id)
                ?? throw new Exception("Failed to create doctor");
        }

        public async Task<DoctorDto?> UpdateDoctorAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return null;

            if (dto.SpecialityId.HasValue)
                doctor.SpecialityId = dto.SpecialityId;

            if (!string.IsNullOrEmpty(dto.LicenseNumber))
                doctor.LicenseNumber = dto.LicenseNumber;

            if (dto.Biography != null)
                doctor.Biography = dto.Biography;

            if (dto.YearsOfExperience.HasValue)
                doctor.YearsOfExperience = dto.YearsOfExperience;

            if (dto.IsAvailable.HasValue)
                doctor.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();
            return await GetDoctorByIdAsync(id);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DoctorExistsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(d => d.Id == id);
        }
        public async Task<List<DoctorDto>> GetDoctorByUserIdAsync(int userId)
        {
            return await _context.Doctors
                .Where(d => d.UserId == userId)
                .Include(d => d.User)
                .Include(d => d.Speciality)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                    Email = d.User != null ? d.User.Email : null,
                    SpecialityName = d.Speciality != null ? d.Speciality.SpecialityName.ToString() : null,
                    LicenseNumber = d.LicenseNumber,
                    Biography = d.Biography,
                    YearsOfExperience = d.YearsOfExperience,
                    IsAvailable = d.IsAvailable
                })
                .ToListAsync();
        }
    }
}