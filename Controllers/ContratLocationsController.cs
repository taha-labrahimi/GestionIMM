using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionIMM.Data;
using GestionIMM.Models;

namespace GestionIMM.Controllers
{
    public class ContratLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContratLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContratLocations
        public async Task<IActionResult> Index()
        {
            var Location = await _context.contratLocations
                .Include(t => t.Propriete)
                .Include(t => t.Locataire)
                .ToListAsync();
            return View(Location);
        }

        // GET: ContratLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratLocation = await _context.contratLocations
                .Include(c => c.Locataire)
                .Include(c => c.Propriete)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratLocation == null)
            {
                return NotFound();
            }

            return View(contratLocation);
        }

        // GET: ContratLocations/Create
        public IActionResult Create()
        {
            ViewData["LocataireId"] = new SelectList(_context.clients, "Id", "Nom");
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type");
            return View();
        }

        // POST: ContratLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProprieteId,LocataireId,DateDebut,DateFin,PaiementMensuel,Disponibilite")] ContratLocation contratLocation)
        {

            _context.Add(contratLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
  
            ViewData["LocataireId"] = new SelectList(_context.clients, "Id", "Nom", contratLocation.LocataireId);
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type", contratLocation.ProprieteId);
            return View(contratLocation);
        }

        // GET: ContratLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratLocation = await _context.contratLocations
                .Include(c => c.Locataire)
                .Include(c => c.Propriete)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratLocation == null)
            {
                return NotFound();
            }
            ViewData["LocataireId"] = new SelectList(_context.clients, "Id", "Nom", contratLocation.LocataireId);
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type", contratLocation.ProprieteId);
            return View(contratLocation);
        }

        // POST: ContratLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProprieteId,LocataireId,DateDebut,DateFin,PaiementMensuel,Disponibilite")] ContratLocation contratLocation)
        {
            if (id != contratLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratLocationExists(contratLocation.Id))
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
            ViewData["LocataireId"] = new SelectList(_context.clients, "Id", "Nom", contratLocation.LocataireId);
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type", contratLocation.ProprieteId);
            return View(contratLocation);
        }

        // GET: ContratLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratLocation = await _context.contratLocations
                .Include(c => c.Locataire)
                .Include(c => c.Propriete)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratLocation == null)
            {
                return NotFound();
            }

            return View(contratLocation);
        }

        // POST: ContratLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratLocation = await _context.contratLocations.FindAsync(id);
            if (contratLocation != null)
            {
                _context.contratLocations.Remove(contratLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratLocationExists(int id)
        {
            return _context.contratLocations.Any(e => e.Id == id);
        }
    }
}
