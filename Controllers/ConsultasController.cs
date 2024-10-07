﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Contexto _context;

        public ConsultasController(Contexto context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Consultas
                                   .Include(c => c.paciente)
                                   .Include(c => c.cidade)
                                   .Include(c => c.medico)
                                   .Include(c => c.especialidade)
                                   .Include(c => c.cid)
                                   .Include(c => c.medicamento);
            return View(await contexto.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.paciente)
                .Include(c => c.cidade)
                .Include(c => c.medico)
                .Include(c => c.especialidade)
                .Include(c => c.cid)
                .Include(c => c.medicamento)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            // Carregar dados para os SelectList
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "ID", "nome");
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome");
            ViewData["medicoID"] = new SelectList(_context.Medicos, "ID", "nome");
            ViewData["especialidadeID"] = new SelectList(_context.Especialidades, "ID", "descricao");
            ViewData["cidID"] = new SelectList(_context.Cids, "ID", "descricao");
            ViewData["medicamentoID"] = new SelectList(_context.Medicamentos, "ID", "descricao");
            return View();
        }

        // POST: Consultas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,pacienteID,pacienteCidadeID,pacienteUFID,medicoID,medicoEspecialidadeID,cidID,medicamentoID,qtdeMedicamento")] Consulta consulta)
        {
            var paciente = await _context.Pacientes.Include(p => p.cidade).FirstOrDefaultAsync(p => p.ID == consulta.pacienteID);
            var medicamento = await _context.Medicamentos.FindAsync(consulta.medicamentoID);
            var medico = await _context.Medicos.Include(m => m.especialidade).FirstOrDefaultAsync(m => m.ID == consulta.medicoID);

            if (paciente == null || medico == null || medicamento == null)
            {
                ModelState.AddModelError("", "Dados inválidos. Verifique paciente, médico e medicamento.");
                // Recarregar os SelectList para a view
                LoadSelectLists(consulta);
                return View(consulta);
            }

            consulta.pacienteCidadeID = paciente.cidade.nome;
            consulta.pacienteUFID = paciente.cidade.UF;
            consulta.medicoEspecialidadeID = medico.especialidade.descricao;

            if (consulta.qtdeMedicamento > medicamento.qtdeEstoque)
            {
                ModelState.AddModelError("", "Quantidade de medicamento em estoque insuficiente.");
            }

            if (ModelState.IsValid)
            {
                medicamento.qtdeEstoque -= consulta.qtdeMedicamento;
                _context.Add(consulta);
                _context.Update(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarregar os SelectList para a view
            LoadSelectLists(consulta);
            return View(consulta);
        }

        // Método auxiliar para carregar os SelectLists
        private void LoadSelectLists(Consulta consulta)
        {
            ViewData["cidID"] = new SelectList(_context.Cids, "ID", "descricao", consulta.cidID);
            ViewData["medicamentoID"] = new SelectList(_context.Medicamentos, "ID", "descricao", consulta.medicamentoID);
            ViewData["medicoID"] = new SelectList(_context.Medicos, "ID", "nome", consulta.medicoID);
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "ID", "nome", consulta.pacienteID);
            ViewData["cidadeID"] = new SelectList(_context.Cidades, "ID", "nome");
            ViewData["especialidadeID"] = new SelectList(_context.Especialidades, "ID", "descricao");
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.paciente)
                .Include(c => c.cidade)
                .Include(c => c.medico)
                .Include(c => c.especialidade)
                .Include(c => c.cid)
                .Include(c => c.medicamento)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (consulta == null)
            {
                return NotFound();
            }

            // Carregar os SelectLists
            LoadSelectLists(consulta);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,pacienteID,pacienteCidadeID,pacienteUFID,medicoID,medicoEspecialidadeID,cidID,medicamentoID,qtdeMedicamento")] Consulta consulta)
        {
            if (id != consulta.ID)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(consulta.medicamentoID);
            var paciente = await _context.Pacientes.Include(p => p.cidade).FirstOrDefaultAsync(p => p.ID == consulta.pacienteID);
            var medico = await _context.Medicos.Include(m => m.especialidade).FirstOrDefaultAsync(m => m.ID == consulta.medicoID);

            if (medicamento == null || paciente == null || medico == null)
            {
                ModelState.AddModelError("", "Dados inválidos. Verifique paciente, médico e medicamento.");
                LoadSelectLists(consulta); // Recarregar os SelectLists
                return View(consulta);
            }

            consulta.pacienteCidadeID = paciente.cidade.nome;
            consulta.pacienteUFID = paciente.cidade.UF;
            consulta.medicoEspecialidadeID = medico.especialidade.descricao;

            if (consulta.qtdeMedicamento > medicamento.qtdeEstoque)
            {
                ModelState.AddModelError("", "Quantidade de medicamento em estoque insuficiente.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    medicamento.qtdeEstoque -= consulta.qtdeMedicamento;
                    _context.Update(consulta);
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.ID))
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

            LoadSelectLists(consulta); // Recarregar os SelectLists
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.paciente)
                .Include(c => c.cidade)
                .Include(c => c.medico)
                .Include(c => c.especialidade)
                .Include(c => c.cid)
                .Include(c => c.medicamento)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Método para buscar cidade e UF do paciente
        [HttpGet]
        public JsonResult GetPacienteDetails(int id)
        {
            var paciente = _context.Pacientes
                                   .Include(p => p.cidade)
                                   .Where(p => p.ID == id)
                                   .Select(p => new {
                                       nomeCidade = p.cidade.nome,
                                       uf = p.cidade.UF
                                   }).FirstOrDefault();

            return Json(paciente);
        }

        // Método para buscar especialidade do médico
        [HttpGet]
        public JsonResult GetMedicoEspecialidade(int id)
        {
            var medico = _context.Medicos
                                 .Include(m => m.especialidade)
                                 .Where(m => m.ID == id)
                                 .Select(m => new{
                                     descricaoEspecialidade = m.especialidade.descricao
                                 })
                                 .FirstOrDefault();

            if (medico == null)
            {
                return Json(new { success = false, message = "Médico não encontrado" });
            }

            Console.WriteLine("Especialidade encontrada: " + medico.descricaoEspecialidade); // Log para verificar se os dados estão corretos

            return Json(new { success = true, especialidade = medico.descricaoEspecialidade });
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.ID == id);
        }
    }
}