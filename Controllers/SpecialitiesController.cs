using MedicalAppBackend.Data;
using MedicalAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpecialitiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialities()
        {
            var specialities = await _context.Specialities.ToListAsync();
            return Ok(specialities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialityById(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
                return NotFound($"Speciality with id {id} not found");
            return Ok(speciality);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeciality(Specialities speciality)
        {
            await _context.Specialities.AddAsync(speciality);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSpecialityById), new { id = speciality.Id }, speciality);
        }
    }
}