using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restaurant3.Models;

namespace restaurant3.Controllers
{
    [Authorize]
    public class PlatsController : Controller
    {
        private readonly BdNaamiContext _context;

        public PlatsController(BdNaamiContext context)
        {
            _context = context;
        }

        // GET: Plats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plats.ToListAsync());
        }

        // GET: Plats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plat = await _context.Plats
                .FirstOrDefaultAsync(m => m.IdPlat == id);
            if (plat == null)
            {
                return NotFound();
            }

            return View(plat);
        }

        // GET: Plats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlat,NomPlat,Description,Prix,Disponible")] Plat plat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plat);
        }

        // GET: Plats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plat = await _context.Plats.FindAsync(id);
            if (plat == null)
            {
                return NotFound();
            }
            return View(plat);
        }

        // POST: Plats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlat,NomPlat,Description,Prix,Disponible")] Plat plat)
        {
            if (id != plat.IdPlat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatExists(plat.IdPlat))
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
            return View(plat);
        }

        // GET: Plats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plat = await _context.Plats
                .FirstOrDefaultAsync(m => m.IdPlat == id);
            if (plat == null)
            {
                return NotFound();
            }

            return View(plat);
        }

        // POST: Plats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plat = await _context.Plats.FindAsync(id);
            if (plat != null)
            {
                _context.Plats.Remove(plat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatExists(int id)
        {
            return _context.Plats.Any(e => e.IdPlat == id);
        }
    }
}
