using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecninca.Data;
using PruebaTecninca.Models;

namespace PruebaTecninca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresAPIController : ControllerBase
    {
        private readonly Clase_Context _context;

        public ProfesoresAPIController(Clase_Context context)
        {
            _context = context;
        }

        // GET: api/ProfesoresAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesores>>> GetProfesores()
        {
            return await _context.Profesores.ToListAsync();
        }

        // GET: api/ProfesoresAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesores>> GetProfesores(int id)
        {
            var profesores = await _context.Profesores.FindAsync(id);

            if (profesores == null)
            {
                return NotFound();
            }

            return profesores;
        }

        // PUT: api/ProfesoresAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesores(int id, Profesores profesores)
        {
            if (id != profesores.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProfesoresAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesores>> PostProfesores(Profesores profesores)
        {
            _context.Profesores.Add(profesores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesores", new { id = profesores.Id }, profesores);
        }

        // DELETE: api/ProfesoresAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesores(int id)
        {
            var profesores = await _context.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return NotFound();
            }

            _context.Profesores.Remove(profesores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesoresExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
