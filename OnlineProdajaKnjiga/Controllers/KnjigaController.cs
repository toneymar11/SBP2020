using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineProdajaKnjiga.Models;

namespace OnlineProdajaKnjiga.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly online_bookstoreContext _context;

        public KnjigaController(online_bookstoreContext context)
        {
            _context = context;
        }

        // GET: Knjiga
        public async Task<IActionResult> Index()
        {
            var online_bookstoreContext = _context.Knjiga.Include(k => k.FkAutorNavigation).Include(k => k.FkIzdavackaKucaNavigation);
            return View(await online_bookstoreContext.ToListAsync());
        }

        // GET: Knjiga/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.FkAutorNavigation)
                .Include(k => k.FkIzdavackaKucaNavigation)
                .FirstOrDefaultAsync(m => m.IdKnjiga == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            ViewData["FkAutor"] = new SelectList(_context.Autor, "IdAutor", "FullName", knjiga.FkAutor);
            ViewData["FkIzdavackaKuca"] = new SelectList(_context.IzdavackaKuca, "IdIzdavackaKuca", "Naziv", knjiga.FkIzdavackaKuca);
            return View(knjiga);
        }

        
        // GET: Knjiga/Create
        public IActionResult Create()
        {
            ViewData["FkAutor"] = new SelectList(_context.Autor, "IdAutor", "FullName");
          
            ViewData["FkIzdavackaKuca"] = new SelectList(_context.IzdavackaKuca, "IdIzdavackaKuca", "Naziv");
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKnjiga,FkAutor,FkIzdavackaKuca,Naziv,DatumObjave,Cijena,BrojStranica")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor", knjiga.FkAutor);
            ViewData["FkIzdavackaKuca"] = new SelectList(_context.IzdavackaKuca, "IdIzdavackaKuca", "IdIzdavackaKuca", knjiga.FkIzdavackaKuca);
            return View(knjiga);
        }

        // GET: Knjiga/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            ViewData["FkAutor"] = new SelectList(_context.Autor, "IdAutor", "FullName", knjiga.FkAutor);
            ViewData["FkIzdavackaKuca"] = new SelectList(_context.IzdavackaKuca, "IdIzdavackaKuca", "Naziv", knjiga.FkIzdavackaKuca);
            return View(knjiga);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdKnjiga,FkAutor,FkIzdavackaKuca,Naziv,DatumObjave,Cijena,BrojStranica")] Knjiga knjiga)
        {
            if (id != knjiga.IdKnjiga)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(knjiga.IdKnjiga))
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
            ViewData["FkAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor", knjiga.FkAutor);
            ViewData["FkIzdavackaKuca"] = new SelectList(_context.IzdavackaKuca, "IdIzdavackaKuca", "IdIzdavackaKuca", knjiga.FkIzdavackaKuca);
            return View(knjiga);
        }

        // GET: Knjiga/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.FkAutorNavigation)
                .Include(k => k.FkIzdavackaKucaNavigation)
                .FirstOrDefaultAsync(m => m.IdKnjiga == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // POST: Knjiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var knjiga = await _context.Knjiga.FindAsync(id);
            _context.Knjiga.Remove(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigaExists(long id)
        {
            return _context.Knjiga.Any(e => e.IdKnjiga == id);
        }
    }
}
