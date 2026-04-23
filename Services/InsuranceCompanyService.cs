using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class InsuranceCompanyService : IInsuranceCompanyService
    {
        private readonly AppDbContext _context;

        public InsuranceCompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InsuranceCompanyDto>> GetAllCompaniesAsync()
        {
            return await _context.InsuranceCompanies
                .Select(c => new InsuranceCompanyDto
                {
                    IdCompany = c.IdCompany,
                    CompanyName = c.CompanyName,
                    Type = c.Type,
                    ValidDate = c.ValidDate,
                    Description = c.Description,
                    Active = c.Active,
                    Appointments = c.Appointments.Select(a => new AppointmentSummaryDto
                    {
                        IdAppointment = a.IdAppointment,
                        PatientName = a.PatientName,
                        DateTimeAppointment = a.DateTimeAppointment,
                        Reason = a.Reason
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<InsuranceCompanyDto?> GetCompanyByIdAsync(int id)
        {
            return await _context.InsuranceCompanies
                .Where(c => c.IdCompany == id)
                .Select(c => new InsuranceCompanyDto
                {
                    IdCompany = c.IdCompany,
                    CompanyName = c.CompanyName,
                    Type = c.Type,
                    ValidDate = c.ValidDate,
                    Description = c.Description,
                    Active = c.Active,
                    Appointments = c.Appointments.Select(a => new AppointmentSummaryDto
                    {
                        IdAppointment = a.IdAppointment,
                        PatientName = a.PatientName,
                        DateTimeAppointment = a.DateTimeAppointment,
                        Reason = a.Reason
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<InsuranceCompanyDto> CreateCompanyAsync(CreateInsuranceCompanyDto dto)
        {
            var company = new InsuranceCompany
            {
                CompanyName = dto.CompanyName,
                Type = dto.Type,
                ValidDate = dto.ValidDate,
                Description = dto.Description,
                Active = dto.Active
            };

            await _context.InsuranceCompanies.AddAsync(company);
            await _context.SaveChangesAsync();

            return new InsuranceCompanyDto
            {
                IdCompany = company.IdCompany,
                CompanyName = company.CompanyName,
                Type = company.Type,
                ValidDate = company.ValidDate,
                Description = company.Description,
                Active = company.Active,
                Appointments = new List<AppointmentSummaryDto>()
            };
        }

        public async Task<bool> UpdateCompanyAsync(int id, UpdateInsuranceCompanyDto dto)
        {
            var company = await _context.InsuranceCompanies.FindAsync(id);
            if (company == null)
                return false;

            if (dto.CompanyName != null)
                company.CompanyName = dto.CompanyName;
            if (dto.Type != null)
                company.Type = dto.Type;
            if (dto.ValidDate.HasValue)
                company.ValidDate = dto.ValidDate;
            if (dto.Description != null)
                company.Description = dto.Description;
            if (dto.Active.HasValue)
                company.Active = dto.Active;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await _context.InsuranceCompanies
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.IdCompany == id);

            if (company == null)
                return false;

            if (company.Appointments.Any())
                return false;

            _context.InsuranceCompanies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompanyHasAppointmentsAsync(int id)
        {
            return await _context.Appointments.AnyAsync(a => a.IdCompany == id);
        }
    }
}