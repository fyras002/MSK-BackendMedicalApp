using MedicalAppBackend.Data;
using MedicalAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalAppBackend.Services.Interfaces;
using MedicalAppBackend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialitiesController : ControllerBase
    {
        private readonly ISpecialityService _service;

        public SpecialitiesController(ISpecialityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialities()
        {
            var specialities = await _service.GetAllSpecialitiesAsync();
            return Ok(specialities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialityById(int id)
        {
            var speciality = await _service.GetSpecialityByIdAsync(id);
            if (speciality == null)
                return NotFound(new { message = $"Speciality with id {id} not found" });
            return Ok(speciality);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeciality(CreateSpecialityDto dto)
        {
            var created = await _service.CreateSpecialityAsync(dto);
            return CreatedAtAction(nameof(GetSpecialityById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpeciality(int id, UpdateSpecialityDto dto)
        {
            var updated = await _service.UpdateSpecialityAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Speciality with id {id} not found" });
            return Ok(new { message = $"Speciality {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var deleted = await _service.DeleteSpecialityAsync(id);
            if (!deleted)
            {
                var hasDoctors = await _service.HasDoctorsAsync(id);
                if (hasDoctors)
                    return BadRequest(new { message = $"Cannot delete speciality. It has doctors linked." });
                return NotFound(new { message = $"Speciality with id {id} not found" });
            }
            return Ok(new { message = $"Speciality {id} deleted successfully" });
        }
    }
}
