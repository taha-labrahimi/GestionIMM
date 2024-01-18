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
    public class TransactionVentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionVentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransactionVentes
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.transactionVentes
                .Include(t => t.Propriete)
                .Include(t => t.Client)
                .ToListAsync();
            return View(transactions);
            
        }

        // GET: TransactionVentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transactionVente = await _context.transactionVentes
            .Include(t => t.Propriete) // Incluez l'entité Propriete
            .Include(t => t.Client)  // Incluez l'entité Acheteur
            .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionVente == null)
            {
                return NotFound();
            }

            return View(transactionVente);
        }

        // GET: TransactionVentes/Create
        public IActionResult Create()
        {
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type"); // Remplacez "Nom" par le nom de la colonne qui contient le nom des propriétés
            ViewData["AcheteurId"] = new SelectList(_context.clients, "Id", "Nom"); // Assurez-vous que cette ligne correspond à votre modèle de données
            return View();
        }

        // POST: TransactionVentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProprieteId,AcheteurId,DateTransaction,Montant")] TransactionVente transactionVente)
        {

                _context.Add(transactionVente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: TransactionVentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transactionVente = await _context.transactionVentes
            .Include(t => t.Propriete) // Assurez-vous d'inclure la propriété
            .Include(t => t.Client) // Assurez-vous d'inclure l'acheteur
            .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionVente == null)
            {
                return NotFound();
            }
            ViewData["ProprieteId"] = new SelectList(_context.proprietes, "Id", "Type"); // Remplacez "Nom" par le nom de la colonne qui contient le nom des propriétés
            ViewData["AcheteurId"] = new SelectList(_context.clients, "Id", "Nom");
            return View(transactionVente);
        }

        // POST: TransactionVentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProprieteId,AcheteurId,DateTransaction,Montant")] TransactionVente transactionVente)
        {
            if (id != transactionVente.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(transactionVente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionVenteExists(transactionVente.Id))
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

        // GET: TransactionVentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionVente = await _context.transactionVentes
            .Include(t => t.Propriete) // Assurez-vous d'inclure la propriété
            .Include(t => t.Client) // Assurez-vous d'inclure l'acheteur
            .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionVente == null)
            {
                return NotFound();
            }

            return View(transactionVente);
        }

        // POST: TransactionVentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionVente = await _context.transactionVentes.FindAsync(id);
            if (transactionVente != null)
            {
                _context.transactionVentes.Remove(transactionVente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionVenteExists(int id)
        {
            return _context.transactionVentes.Any(e => e.Id == id);
        }
    }
}
