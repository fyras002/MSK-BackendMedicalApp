using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _service.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _service.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound(new { message = $"Appointment with id {id} not found" });
            return Ok(appointment);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = await _service.GetAppointmentsByDoctorAsync(doctorId);
            return Ok(appointments);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(int patientId)
        {
            var appointments = await _service.GetAppointmentsByPatientAsync(patientId);
            return Ok(appointments);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAppointmentsByDate(DateTime date)
        {
            var appointments = await _service.GetAppointmentsByDateAsync(date);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            var created = await _service.CreateAppointmentAsync(dto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = created.IdAppointment }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto dto)
        {
            var updated = await _service.UpdateAppointmentAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Appointment with id {id} not found" });
            return Ok(new { message = $"Appointment {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var deleted = await _service.DeleteAppointmentAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Appointment with id {id} not found" });
            return Ok(new { message = $"Appointment {id} deleted successfully" });
        }
    }
}