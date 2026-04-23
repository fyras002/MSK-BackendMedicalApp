using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IInsuranceCompanyService
    {
        Task<List<InsuranceCompanyDto>> GetAllCompaniesAsync();
        Task<InsuranceCompanyDto?> GetCompanyByIdAsync(int id);
        Task<InsuranceCompanyDto> CreateCompanyAsync(CreateInsuranceCompanyDto dto);
        Task<bool> UpdateCompanyAsync(int id, UpdateInsuranceCompanyDto dto);
        Task<bool> DeleteCompanyAsync(int id);
        Task<bool> CompanyHasAppointmentsAsync(int id);
    }
}