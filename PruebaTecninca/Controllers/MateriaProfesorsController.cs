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
    public class MateriaProfesorsController : Controller
    {
        private readonly Clase_Context _context;

        public MateriaProfesorsController(Clase_Context context)
        {
            _context = context;
        }

        // GET: MateriaProfesors
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriaProfesor.ToListAsync());
        }

        // GET: MateriaProfesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriaProfesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }

            return View(materiaProfesor);
        }

        // GET: MateriaProfesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaProfesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Materia,Id_Profesor")] MateriaProfesor materiaProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaProfesor);
        }

        // GET: MateriaProfesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriaProfesor.FindAsync(id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }
            return View(materiaProfesor);
        }

        // POST: MateriaProfesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Materia,Id_Profesor")] MateriaProfesor materiaProfesor)
        {
            if (id != materiaProfesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaProfesorExists(materiaProfesor.Id))
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
            return View(materiaProfesor);
        }

        // GET: MateriaProfesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaProfesor = await _context.MateriaProfesor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaProfesor == null)
            {
                return NotFound();
            }

            return View(materiaProfesor);
        }

        // POST: MateriaProfesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaProfesor = await _context.MateriaProfesor.FindAsync(id);
            if (materiaProfesor != null)
            {
                _context.MateriaProfesor.Remove(materiaProfesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaProfesorExists(int id)
        {
            return _context.MateriaProfesor.Any(e => e.Id == id);
        }
    }
}
