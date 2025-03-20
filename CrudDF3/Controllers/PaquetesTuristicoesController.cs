using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudDF3.Models;

namespace CrudDF3.Controllers
{
    public class PaquetesTuristicoesController : Controller
    {
        private readonly CrudDf3Context _context;

        public PaquetesTuristicoesController(CrudDf3Context context)
        {
            _context = context;
        }

        // GET: PaquetesTuristicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaquetesTuristicos.ToListAsync());
        }

        // GET: PaquetesTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesTuristico = await _context.PaquetesTuristicos
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesTuristico == null)
            {
                return NotFound();
            }

            return View(paquetesTuristico);
        }

        // GET: PaquetesTuristicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaquetesTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaquete,NombrePaquete,DescripcionPaquete,PrecioPaquete,DisponibilidadPaquete,FechaPaquete,DestinoPaquete,EstadoPaquete,TipoViajePaquete")] PaquetesTuristico paquetesTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquetesTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paquetesTuristico);
        }

        // GET: PaquetesTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesTuristico = await _context.PaquetesTuristicos.FindAsync(id);
            if (paquetesTuristico == null)
            {
                return NotFound();
            }
            return View(paquetesTuristico);
        }

        // POST: PaquetesTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaquete,NombrePaquete,DescripcionPaquete,PrecioPaquete,DisponibilidadPaquete,FechaPaquete,DestinoPaquete,EstadoPaquete,TipoViajePaquete")] PaquetesTuristico paquetesTuristico)
        {
            if (id != paquetesTuristico.IdPaquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquetesTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquetesTuristicoExists(paquetesTuristico.IdPaquete))
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
            return View(paquetesTuristico);
        }

        // GET: PaquetesTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesTuristico = await _context.PaquetesTuristicos
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesTuristico == null)
            {
                return NotFound();
            }

            return View(paquetesTuristico);
        }

        // POST: PaquetesTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquetesTuristico = await _context.PaquetesTuristicos.FindAsync(id);
            if (paquetesTuristico != null)
            {
                _context.PaquetesTuristicos.Remove(paquetesTuristico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaquetesTuristicoExists(int id)
        {
            return _context.PaquetesTuristicos.Any(e => e.IdPaquete == id);
        }
    }
}
