using MedicalAppBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using MedicalAppBackend.Models;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PatientsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients);
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetActivePatients()
        {
            var patients = await _context.Patients
                .Where(p => p.Active == true)
                .ToListAsync();
            return Ok(patients);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(Patients patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound($"patient with id : {id} not found !!");
            return Ok(patient);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
                return NotFound($"Patient with ID {id} not found");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return Ok($"patient with id :{patient.IdPatient} was removed !!");
        }

    }
}
