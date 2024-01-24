using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecninca.Data;
using PruebaTecninca.Models;

namespace PruebaTecninca.Controllers
{
    public class MateriaEstudiantesController : Controller
    {
        private readonly Clase_Context _context;

        public MateriaEstudiantesController(Clase_Context context)
        {
            _context = context;
        }

        // GET: MateriaEstudiantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriaEstudiante.ToListAsync());
        }

        // GET: MateriaEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEstudiante = await _context.MateriaEstudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaEstudiante == null)
            {
                return NotFound();
            }

            return View(materiaEstudiante);
        }

        // GET: MateriaEstudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Materia,Id_Estudiante")] MateriaEstudiante materiaEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaEstudiante);
        }

        // GET: MateriaEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEstudiante = await _context.MateriaEstudiante.FindAsync(id);
            if (materiaEstudiante == null)
            {
                return NotFound();
            }
            return View(materiaEstudiante);
        }

        // POST: MateriaEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Materia,Id_Estudiante")] MateriaEstudiante materiaEstudiante)
        {
            if (id != materiaEstudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaEstudianteExists(materiaEstudiante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materiaEstudiante);
        }

        // GET: MateriaEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEstudiante = await _context.MateriaEstudiante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaEstudiante == null)
            {
                return NotFound();
            }

            return View(materiaEstudiante);
        }

        // POST: MateriaEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaEstudiante = await _context.MateriaEstudiante.FindAsync(id);
            if (materiaEstudiante != null)
            {
                _context.MateriaEstudiante.Remove(materiaEstudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaEstudianteExists(int id)
        {
            return _context.MateriaEstudiante.Any(e => e.Id == id);
        }
    }
}
