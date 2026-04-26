using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationsController : ControllerBase
    {
        private readonly IConsultationService _service;

        public ConsultationsController(IConsultationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsultations()
        {
            var consultations = await _service.GetAllConsultationsAsync();
            return Ok(consultations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultationById(int id)
        {
            var consultation = await _service.GetConsultationByIdAsync(id);
            if (consultation == null)
                return NotFound(new { message = $"Consultation with id {id} not found" });
            return Ok(consultation);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetConsultationsByDoctor(int doctorId)
        {
            var consultations = await _service.GetConsultationsByDoctorAsync(doctorId);
            return Ok(consultations);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetConsultationsByPatient(int patientId)
        {
            var consultations = await _service.GetConsultationsByPatientAsync(patientId);
            return Ok(consultations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsultation(CreateConsultationDto dto)
        {
            var created = await _service.CreateConsultationAsync(dto);
            return CreatedAtAction(nameof(GetConsultationById), new { id = created.IdConsultation }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsultation(int id, UpdateConsultationDto dto)
        {
            var updated = await _service.UpdateConsultationAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Consultation with id {id} not found" });
            return Ok(new { message = $"Consultation {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultation(int id)
        {
            var deleted = await _service.DeleteConsultationAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Consultation with id {id} not found" });
            return Ok(new { message = $"Consultation {id} deleted successfully" });
        }
    }
}