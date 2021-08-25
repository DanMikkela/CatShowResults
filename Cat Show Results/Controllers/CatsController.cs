using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cat_Show_Results.Models;

namespace Cat_Show_Results.Controllers
{
    public class CatsController : Controller
    {
        private readonly AppDbContext _context;

        public CatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Cats.Include(k => k.Breed);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var katt = await _context.Cats
                .Include(k => k.Breed)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (katt == null)
            {
                return NotFound();
            }

            return View(katt);
        }

        // GET: Cater/Create
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId");
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,Number,Name,BreedName,EMS,Sex,Born,ImageUrl,ClassNr,BreedId")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", cat.BreedId);
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", cat.BreedId);
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,Number,Name,BreedName,EMS,Sex,Born,ImageUrl,ClassNr,BreedId")] Cat cat)
        {
            if (id != cat.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.CatId))
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
            ViewData["BreedId"] = new SelectList(_context.Breeds, "BreedId", "BreedId", cat.BreedId);
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(k => k.Breed)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Cats/_Partial/5
        public async Task<IActionResult> _Partial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var katt = await _context.Cats
                .Include(k => k.Breed)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (katt == null)
            {
                return NotFound();
            }

            return View(katt);
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.CatId == id);
        }
    }
}
