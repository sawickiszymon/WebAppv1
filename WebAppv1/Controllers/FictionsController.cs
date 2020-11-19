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
    public class FictionsController : Controller
    {
        private readonly WebAppv1Context _context;

        public FictionsController(WebAppv1Context context)
        {
            _context = context;
        }

        // GET: Fictions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fiction.ToListAsync());
        }

        // GET: Fictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiction = await _context.Fiction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiction == null)
            {
                return NotFound();
            }
            return View(fiction);
        }

        // GET: Fictions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fictions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,FictionType,Description")] Fiction fiction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiction);
        }

        // GET: Fictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiction = await _context.Fiction.FindAsync(id);
            if (fiction == null)
            {
                return NotFound();
            }
            return View(fiction);
        }

        // POST: Fictions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,FictionType,Description")] Fiction fiction)
        {
            if (id != fiction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FictionExists(fiction.Id))
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
            return View(fiction);
        }

        // GET: Fictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiction = await _context.Fiction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiction == null)
            {
                return NotFound();
            }

            return View(fiction);
        }

        // POST: Fictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fiction = await _context.Fiction.FindAsync(id);
            _context.Fiction.Remove(fiction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FictionExists(int id)
        {
            return _context.Fiction.Any(e => e.Id == id);
        }
    }
}
