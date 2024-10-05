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
    public class MedicosController : Controller
    {
        private readonly Contexto _context;

        public MedicosController(Contexto context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Medicos.Include(m => m.cidade).Include(m => m.especialidade);
            return View(await contexto.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.cidade)
                .Include(m => m.especialidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome");
            ViewData["especialidadeID"] = new SelectList(_context.Especialidades, "ID", "descricao");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome,especialidadeID,endereco,telefone,cidadeID,UFID")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Cidades = new SelectList(_context.Cidades, "ID", "nome", medico.cidadeID);
            ViewBag.Especialidades = new SelectList(_context.Especialidades, "ID", "descricao", medico.especialidadeID);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome", medico.cidadeID);
            ViewData["especialidadeID"] = new SelectList(_context.Especialidades, "ID", "descricao", medico.especialidadeID);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome,especialidadeID,endereco,telefone,cidadeID,UFID")] Medico medico)
        {
            if (id != medico.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.ID))
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
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome", medico.cidadeID);
            ViewData["especialidadeID"] = new SelectList(_context.Especialidades, "ID", "descricao", medico.especialidadeID);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.cidade)
                .Include(m => m.especialidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método que busca a UF com base na cidade selecionada (AJAX)
        [HttpGet]
        public JsonResult GetUFByCidade(int cidadeID)
        {
            var cidade = _context.Cidades.FirstOrDefault(c => c.ID == cidadeID);
            if (cidade != null)
            {
                return Json(cidade.UF); // Retorna a sigla da UF associada à cidade
            }
            return Json(""); // Caso a cidade não seja encontrada
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.ID == id);
        }
    }
}
