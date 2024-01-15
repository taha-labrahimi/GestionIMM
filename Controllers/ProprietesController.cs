using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionIMM.Data;
using GestionIMM.Models;
using Azure.Core;

namespace GestionIMM.Controllers
{
    public class ProprietesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProprietesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

        // POST: Proprietes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Propriete propriete,IFormFile uploadimage)
        {

                if (uploadimage != null && uploadimage.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadimage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadimage.CopyToAsync(fileStream);
                    }
                    propriete.Image = fileName; 
                }

                _context.Add(propriete);
                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Edit(int id, Propriete propriete, IFormFile uploadimage)
        {
            if (id != propriete.Id)
            {
                return NotFound();
            }
                try
                {
                    if (uploadimage != null && uploadimage.Length > 0)
                    {
                        var fileName = Path.GetFileName(uploadimage.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await uploadimage.CopyToAsync(fileStream);
                        }
                        propriete.Image = fileName; // Mettre à jour le chemin de l'image
                    }

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
