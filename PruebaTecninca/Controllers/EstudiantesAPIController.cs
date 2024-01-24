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
    public class EstudiantesAPIController : ControllerBase
    {
        private readonly Clase_Context _context;

        public EstudiantesAPIController(Clase_Context context)
        {
            _context = context;
        }

        // GET: api/EstudiantesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiantes>>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        // GET: api/EstudiantesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiantes>> GetEstudiantes(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);

            if (estudiantes == null)
            {
                return NotFound();
            }

            return estudiantes;
        }

        // PUT: api/EstudiantesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiantes(int id, Estudiantes estudiantes)
        {
            if (id != estudiantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudiantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudiantesExists(id))
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

        // POST: api/EstudiantesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiantes>> PostEstudiantes(Estudiantes estudiantes)
        {
            _context.Estudiantes.Add(estudiantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiantes", new { id = estudiantes.Id }, estudiantes);
        }

        // DELETE: api/EstudiantesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiantes(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
