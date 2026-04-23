using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceCompanyController : ControllerBase
    {
        private readonly IInsuranceCompanyService _service;

        public InsuranceCompanyController(IInsuranceCompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _service.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _service.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound(new { message = $"Company with id {id} not found" });
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateInsuranceCompanyDto dto)
        {
            var created = await _service.CreateCompanyAsync(dto);
            return CreatedAtAction(nameof(GetCompanyById), new { id = created.IdCompany }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, UpdateInsuranceCompanyDto dto)
        {
            var updated = await _service.UpdateCompanyAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Company with id {id} not found" });
            return Ok(new { message = $"Company {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var deleted = await _service.DeleteCompanyAsync(id);
            if (!deleted)
            {
                var hasAppointments = await _service.CompanyHasAppointmentsAsync(id);
                if (hasAppointments)
                    return BadRequest(new { message = $"Cannot delete company. It has appointments linked." });
                return NotFound(new { message = $"Company with id {id} not found" });
            }
            return Ok(new { message = $"Company {id} deleted successfully" });
        }
    }
}