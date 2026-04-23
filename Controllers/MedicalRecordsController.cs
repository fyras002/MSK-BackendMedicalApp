using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordsController(IMedicalRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var records = await _service.GetAllMedicalRecordsAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            var record = await _service.GetMedicalRecordByIdAsync(id);
            if (record == null)
                return NotFound(new { message = $"Medical record with id {id} not found" });
            return Ok(record);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetMedicalRecordByPatientId(int patientId)
        {
            var record = await _service.GetMedicalRecordByPatientIdAsync(patientId);
            if (record == null)
                return NotFound(new { message = $"Medical record for patient {patientId} not found" });
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord(CreateMedicalRecordDto dto)
        {
            if (dto.IdPatient.HasValue)
            {
                var hasRecord = await _service.PatientHasMedicalRecordAsync(dto.IdPatient.Value);
                if (hasRecord)
                    return BadRequest(new { message = $"Patient {dto.IdPatient} already has a medical record" });
            }

            var created = await _service.CreateMedicalRecordAsync(dto);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = created.IdMedicalRecord }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, UpdateMedicalRecordDto dto)
        {
            var updated = await _service.UpdateMedicalRecordAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Medical record with id {id} not found" });
            return Ok(new { message = $"Medical record {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(int id)
        {
            var deleted = await _service.DeleteMedicalRecordAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Medical record with id {id} not found" });
            return Ok(new { message = $"Medical record {id} deleted successfully" });
        }
    }
}