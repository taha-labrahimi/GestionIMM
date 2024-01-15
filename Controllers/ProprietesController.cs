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
    public class ProprietesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProprietesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proprietes
        public async Task<IActionResult> Index()
        {
            return View(await _context.proprietes.ToListAsync());
        }

        // GET: Proprietes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.proprietes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propriete == null)
            {
                return NotFound();
            }

            return View(propriete);
        }

        // GET: Proprietes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Taille,Emplacement,Caracteristiques")] Propriete propriete, IFormFile uploadedImage)
        {
            if (!ModelState.IsValid)
            {
                // Parcourir et journaliser toutes les erreurs de validation
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        // Journaliser le message d'erreur
                        System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                    }
                }
                return View(propriete);
            }
            if (uploadedImage != null && uploadedImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await uploadedImage.CopyToAsync(memoryStream);
                    propriete.Image = memoryStream.ToArray();
                }
            }
            else
            {
                // Si aucune image n'est téléchargée et que le champ est facultatif
                propriete.Image = null;
            }

            // Ajouter l'objet propriete au contexte et sauvegarder les changements
            _context.Add(propriete);
            await _context.SaveChangesAsync();

            // Rediriger vers la méthode d'action 'Index' après l'ajout de l'objet
            return RedirectToAction(nameof(Index));
        }

        // GET: Proprietes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.proprietes.FindAsync(id);
            if (propriete == null)
            {
                return NotFound();
            }
            return View(propriete);
        }

        // POST: Proprietes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Taille,Emplacement,Caracteristiques,Image")] Propriete propriete)
        {
            if (id != propriete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propriete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprieteExists(propriete.Id))
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
            return View(propriete);
        }

        // GET: Proprietes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.proprietes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propriete == null)
            {
                return NotFound();
            }

            return View(propriete);
        }

        // POST: Proprietes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propriete = await _context.proprietes.FindAsync(id);
            if (propriete != null)
            {
                _context.proprietes.Remove(propriete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprieteExists(int id)
        {
            return _context.proprietes.Any(e => e.Id == id);
        }
    }
}
