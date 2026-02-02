using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaBackend.Data;
using ClinicaBackend.Models;

namespace ClinicaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // La URL será: api/pacientes
    public class PacientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        // POST: api/pacientes
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPacientes), new { id = paciente.Id }, paciente);
        }

        // PUT: api/pacientes/5 (EDITAR)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pacientes.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // DELETE: api/pacientes/5 (BORRAR)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}