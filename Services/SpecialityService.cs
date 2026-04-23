using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using MedicalAppBackend.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly AppDbContext _context;

        public SpecialityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SpecialityDto>> GetAllSpecialitiesAsync()
        {
            return await _context.Specialities
                .Select(s => new SpecialityDto
                {
                    Id = s.Id,
                    SpecialityName = s.SpecialityName.ToString(),
                    Description = s.Description,
                    Doctors = s.Doctors.Select(d => new DoctorSummaryDto
                    {
                        Id = d.Id,
                        FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                        LicenseNumber = d.LicenseNumber,
                        YearsOfExperience = d.YearsOfExperience,
                        IsAvailable = d.IsAvailable
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<SpecialityDto?> GetSpecialityByIdAsync(int id)
        {
            return await _context.Specialities
                .Where(s => s.Id == id)
                .Select(s => new SpecialityDto
                {
                    Id = s.Id,
                    SpecialityName = s.SpecialityName.ToString(),
                    Description = s.Description,
                    Doctors = s.Doctors.Select(d => new DoctorSummaryDto
                    {
                        Id = d.Id,
                        FullName = d.User != null ? $"{d.User.Firstname} {d.User.Lastname}" : "N/A",
                        LicenseNumber = d.LicenseNumber,
                        YearsOfExperience = d.YearsOfExperience,
                        IsAvailable = d.IsAvailable
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<SpecialityDto> CreateSpecialityAsync(CreateSpecialityDto dto)
        {
            var speciality = new Specialities
            {
                SpecialityName = (SpecialityEnum)dto.SpecialityName,
                Description = dto.Description
            };

            await _context.Specialities.AddAsync(speciality);
            await _context.SaveChangesAsync();

            return new SpecialityDto
            {
                Id = speciality.Id,
                SpecialityName = speciality.SpecialityName.ToString(),
                Description = speciality.Description,
                Doctors = new List<DoctorSummaryDto>()
            };
        }

        public async Task<bool> UpdateSpecialityAsync(int id, UpdateSpecialityDto dto)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
                return false;

            if (dto.SpecialityName.HasValue)
                speciality.SpecialityName = (SpecialityEnum)dto.SpecialityName.Value;
            if (dto.Description != null)
                speciality.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSpecialityAsync(int id)
        {
            var speciality = await _context.Specialities
                .Include(s => s.Doctors)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (speciality == null)
                return false;

            if (speciality.Doctors.Any())
                return false;

            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasDoctorsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(d => d.SpecialityId == id);
        }
    }
}