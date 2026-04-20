using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableDoctors()
        {
            var doctors = await _doctorService.GetAvailableDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("speciality/{specialityId}")]
        public async Task<IActionResult> GetDoctorsBySpeciality(int specialityId)
        {
            var doctors = await _doctorService.GetDoctorsBySpecialityAsync(specialityId);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound(new { message = $"Doctor with id {id} not found" });
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            var created = await _doctorService.CreateDoctorAsync(dto);
            return CreatedAtAction(nameof(GetDoctorById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, UpdateDoctorDto dto)
        {
            var updated = await _doctorService.UpdateDoctorAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = $"Doctor with id {id} not found" });
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var deleted = await _doctorService.DeleteDoctorAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Doctor with id {id} not found" });
            return Ok(new { message = $"Doctor with id {id} was removed" });
        }
    }
}