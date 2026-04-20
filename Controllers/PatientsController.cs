using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActivePatients()
        {
            var patients = await _patientService.GetActivePatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound(new { message = $"Patient with id {id} not found" });
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(CreatePatientDto dto)
        {
            var created = await _patientService.CreatePatientAsync(dto);
            return CreatedAtAction(nameof(GetPatientById), new { id = created.IdPatient }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deleted = await _patientService.DeletePatientAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Patient with ID {id} not found" });

            return Ok(new { message = $"Patient with id {id} was removed" });
        }
    }
}