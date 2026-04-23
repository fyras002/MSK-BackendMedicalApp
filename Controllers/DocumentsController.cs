using MedicalAppBackend.DTOs;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentsController(IDocumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var documents = await _service.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _service.GetDocumentByIdAsync(id);
            if (document == null)
                return NotFound(new { message = $"Document with id {id} not found" });
            return Ok(document);
        }

        [HttpGet("medicalrecord/{medicalRecordId}")]
        public async Task<IActionResult> GetDocumentsByMedicalRecord(int medicalRecordId)
        {
            var documents = await _service.GetDocumentsByMedicalRecordAsync(medicalRecordId);
            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument(CreateDocumentDto dto)
        {
            var created = await _service.CreateDocumentAsync(dto);
            return CreatedAtAction(nameof(GetDocumentById), new { id = created.IdDocument }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, UpdateDocumentDto dto)
        {
            var updated = await _service.UpdateDocumentAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Document with id {id} not found" });
            return Ok(new { message = $"Document {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var deleted = await _service.DeleteDocumentAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Document with id {id} not found" });
            return Ok(new { message = $"Document {id} deleted successfully" });
        }
    }
}