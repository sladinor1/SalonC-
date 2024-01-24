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
    public class MateriasAPIController : ControllerBase
    {
        private readonly Clase_Context _context;

        public MateriasAPIController(Clase_Context context)
        {
            _context = context;
        }

        // GET: api/MateriasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materias>>> GetMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        // GET: api/MateriasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materias>> GetMaterias(int id)
        {
            var materias = await _context.Materias.FindAsync(id);

            if (materias == null)
            {
                return NotFound();
            }

            return materias;
        }

        // PUT: api/MateriasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterias(int id, Materias materias)
        {
            if (id != materias.Id)
            {
                return BadRequest();
            }

            _context.Entry(materias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriasExists(id))
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

        // POST: api/MateriasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materias>> PostMaterias(Materias materias)
        {
            _context.Materias.Add(materias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterias", new { id = materias.Id }, materias);
        }

        // DELETE: api/MateriasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterias(int id)
        {
            var materias = await _context.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriasExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
