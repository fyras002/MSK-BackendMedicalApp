using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionsController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _service.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var prescription = await _service.GetPrescriptionByIdAsync(id);
            if (prescription == null)
                return NotFound(new { message = $"Prescription with id {id} not found" });
            return Ok(prescription);
        }

        [HttpGet("document/{documentId}")]
        public async Task<IActionResult> GetPrescriptionsByDocument(int documentId)
        {
            var prescriptions = await _service.GetPrescriptionsByDocumentAsync(documentId);
            return Ok(prescriptions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto dto)
        {
            var created = await _service.CreatePrescriptionAsync(dto);
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = created.IdPerscription }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, UpdatePrescriptionDto dto)
        {
            var updated = await _service.UpdatePrescriptionAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Prescription with id {id} not found" });
            return Ok(new { message = $"Prescription {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var deleted = await _service.DeletePrescriptionAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Prescription with id {id} not found" });
            return Ok(new { message = $"Prescription {id} deleted successfully" });
        }
    }
}