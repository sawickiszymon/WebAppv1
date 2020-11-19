using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecApp.Models;
using WebAppv1.Data;

namespace WebAppv1.Controllers
{
    public class FictionDetailsController : Controller
    {
        private readonly WebAppv1Context _context;

        public FictionDetailsController(WebAppv1Context context)
        {
            _context = context;
        }

        // GET: FictionDetails
        public async Task<IActionResult> Index()
        {
            var webAppv1Context = _context.FictionDetails.Include(f => f.Fiction);
            return View(await webAppv1Context.ToListAsync());
        }

        // GET: FictionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fictionDetails = await _context.FictionDetails
                .Include(f => f.Fiction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fictionDetails == null)
            {
                return NotFound();
            }

            return View(fictionDetails);
        }

        // GET: FictionDetails/Create
        public IActionResult Create()
        {
            ViewData["FictionId"] = new SelectList(_context.Fiction, "Id", "Author");
            return View();
        }

        // POST: FictionDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FictionType,Description,FictionId")] FictionDetails fictionDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fictionDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FictionId"] = new SelectList(_context.Fiction, "Id", "Author", fictionDetails.FictionId);
            return View(fictionDetails);
        }

        // GET: FictionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fictionDetails = await _context.FictionDetails.FindAsync(id);
            if (fictionDetails == null)
            {
                return NotFound();
            }
            ViewData["FictionId"] = new SelectList(_context.Fiction, "Id", "Author", fictionDetails.FictionId);
            return View(fictionDetails);
        }

        // POST: FictionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FictionType,Description,FictionId")] FictionDetails fictionDetails)
        {
            if (id != fictionDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fictionDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FictionDetailsExists(fictionDetails.Id))
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
            ViewData["FictionId"] = new SelectList(_context.Fiction, "Id", "Author", fictionDetails.FictionId);
            return View(fictionDetails);
        }

        // GET: FictionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fictionDetails = await _context.FictionDetails
                .Include(f => f.Fiction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fictionDetails == null)
            {
                return NotFound();
            }

            return View(fictionDetails);
        }

        // POST: FictionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fictionDetails = await _context.FictionDetails.FindAsync(id);
            _context.FictionDetails.Remove(fictionDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FictionDetailsExists(int id)
        {
            return _context.FictionDetails.Any(e => e.Id == id);
        }
    }
}
