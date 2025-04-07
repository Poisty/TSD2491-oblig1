using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBruker.Data;
using TSD2491_oblig_1_261660.Models;

namespace TSD2491_oblig_1_261660.Controllers
{
    public class BrukerController : Controller
    {
        private readonly BrukerContext _context;

        public BrukerController(BrukerContext context)
        {
            _context = context;
        }

        // GET: Bruker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bruker.ToListAsync());
        }

        // GET: Bruker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bruker == null)
            {
                return NotFound();
            }

            return View(bruker);
        }

        // GET: Bruker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bruker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Kontakt,Spill")] Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bruker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bruker);
        }

        // GET: Bruker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker.FindAsync(id);
            if (bruker == null)
            {
                return NotFound();
            }
            return View(bruker);
        }

        // POST: Bruker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,Kontakt,Spill")] Bruker bruker)
        {
            if (id != bruker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bruker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrukerExists(bruker.Id))
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
            return View(bruker);
        }

        // GET: Bruker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bruker == null)
            {
                return NotFound();
            }

            return View(bruker);
        }

        // POST: Bruker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bruker = await _context.Bruker.FindAsync(id);
            if (bruker != null)
            {
                _context.Bruker.Remove(bruker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrukerExists(int id)
        {
            return _context.Bruker.Any(e => e.Id == id);
        }
    }
}
