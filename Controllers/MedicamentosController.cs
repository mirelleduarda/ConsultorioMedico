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
    public class MedicamentosController : Controller
    {
        private readonly Contexto _context;

        public MedicamentosController(Contexto context)
        {
            _context = context;

        }

        // GET: Medicamentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Medicamentos;

            // Obtém a lista de medicamentos
            var medicamentos = await contexto.ToListAsync();

            // Inicializa a variável para o total
            decimal valorTotal = 0;

            // Soma manualmente os valores de todas as consultas
            foreach (var medicamento in medicamentos)
            {
                // Verifica se ValorConsulta não é nulo
                if (medicamento.precoUnitario.HasValue) // ou if (consulta.valorConsulta != null)
                {
                    valorTotal += medicamento.precoUnitario.Value; // Usa .Value para acessar o valor
                }
            }

            // Passa o total para a View via ViewBag
            ViewBag.valorTotal = valorTotal;

            return View(await contexto.ToListAsync());
        }

        // GET: Medicamentos/BuscarMedicamento
        public async Task<IActionResult> BuscarMedicamento()
        {
            var viewModel = new MedicamentoViewModel
            {
                Medicamentos = await _context.Medicamentos
                    .Select(m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.descricao // Supondo que 'Descricao' é uma propriedade do seu modelo Medicamento
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,descricao,qtdeEstoque,estoqueMin,estoqueMax,precoUnitario")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,descricao,qtdeEstoque,estoqueMin,estoqueMax,precoUnitario")] Medicamento medicamento)
        {
            if (id != medicamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.ID))
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
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
            return _context.Medicamentos.Any(e => e.ID == id);
        }

        [HttpPost]
        public JsonResult BuscarDetalhes(int medicamentoID)
        {
            var medicamento = _context.Medicamentos.Find(medicamentoID);
            if (medicamento == null)
            {
                return Json(null);
            }

            return Json(new
            {
                descricao = medicamento.descricao,
                qtdeEstoque = medicamento.qtdeEstoque,
                estoqueMin = medicamento.estoqueMin,
                estoqueMax = medicamento.estoqueMax,
                precoUnitario = medicamento.precoUnitario
            });
        }
    }
}
