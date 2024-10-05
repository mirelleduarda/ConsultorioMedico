using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.Controllers
{
    public class CidsController : Controller
    {
        private readonly Contexto _context;

        public CidsController(Contexto context)
        {
            _context = context;
        }

        // GET: Cids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cids.ToListAsync());
        }

        // GET: Cids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cid = await _context.Cids
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cid == null)
            {
                return NotFound();
            }

            return View(cid);
        }

        // GET: Cids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descricao")] Cid cid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cid);
        }

        // GET: Cids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cid = await _context.Cids.FindAsync(id);
            if (cid == null)
            {
                return NotFound();
            }
            return View(cid);
        }

        // POST: Cids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descricao")] Cid cid)
        {
            if (id != cid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidExists(cid.ID))
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
            return View(cid);
        }

        // GET: Cids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cid = await _context.Cids
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cid == null)
            {
                return NotFound();
            }

            return View(cid);
        }

        // POST: Cids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cid = await _context.Cids.FindAsync(id);
            if (cid != null)
            {
                _context.Cids.Remove(cid);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidExists(int id)
        {
            return _context.Cids.Any(e => e.ID == id);
        }
    }
}
