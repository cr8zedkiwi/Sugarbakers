using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sugarbakers.Models;

namespace Sugarbakers.Controllers
{
    public class ZipcodesController : Controller
    {
        private readonly SugarbakersCh12Context _context;

        public ZipcodesController(SugarbakersCh12Context context)
        {
            _context = context;
        }

        // GET: Zipcodes
        public async Task<IActionResult> Index()
        {
              return _context.Zipcodes != null ? 
                          View(await _context.Zipcodes.ToListAsync()) :
                          Problem("Entity set 'SugarbakersCh12Context.Zipcodes'  is null.");
        }

        // GET: Zipcodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Zipcodes == null)
            {
                return NotFound();
            }

            var zipcode = await _context.Zipcodes
                .FirstOrDefaultAsync(m => m.Zipcode1 == id);
            if (zipcode == null)
            {
                return NotFound();
            }

            return View(zipcode);
        }

        // GET: Zipcodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zipcodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Zipcode1,City,State")] Zipcode zipcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zipcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zipcode);
        }

        // GET: Zipcodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Zipcodes == null)
            {
                return NotFound();
            }

            var zipcode = await _context.Zipcodes.FindAsync(id);
            if (zipcode == null)
            {
                return NotFound();
            }
            return View(zipcode);
        }

        // POST: Zipcodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Zipcode1,City,State")] Zipcode zipcode)
        {
            if (id != zipcode.Zipcode1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zipcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZipcodeExists(zipcode.Zipcode1))
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
            return View(zipcode);
        }

        // GET: Zipcodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Zipcodes == null)
            {
                return NotFound();
            }

            var zipcode = await _context.Zipcodes
                .FirstOrDefaultAsync(m => m.Zipcode1 == id);
            if (zipcode == null)
            {
                return NotFound();
            }

            return View(zipcode);
        }

        // POST: Zipcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Zipcodes == null)
            {
                return Problem("Entity set 'SugarbakersCh12Context.Zipcodes'  is null.");
            }
            var zipcode = await _context.Zipcodes.FindAsync(id);
            if (zipcode != null)
            {
                _context.Zipcodes.Remove(zipcode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZipcodeExists(string id)
        {
          return (_context.Zipcodes?.Any(e => e.Zipcode1 == id)).GetValueOrDefault();
        }
    }
}
