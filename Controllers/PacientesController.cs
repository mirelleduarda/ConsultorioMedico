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
    public class PacientesController : Controller
    {
        private readonly Contexto _context;

        public PacientesController(Contexto context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pacientes.Include(p => p.cidade);
            return View(await contexto.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.cidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome");
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome,endereco,cidadeID,UFID")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarrega as cidades caso haja erro de validação
            ViewBag.Cidades = new SelectList(_context.Cidades, "ID", "nome", paciente.cidadeID);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome", paciente.cidadeID);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome,endereco,cidadeID,UFID")] Paciente paciente)
        {
            if (id != paciente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.ID))
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
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome", paciente.cidadeID);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.cidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método que busca a UF com base na cidade selecionada (AJAX)
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

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.ID == id);
        }
    }
}
