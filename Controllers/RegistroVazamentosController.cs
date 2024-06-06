using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OceanTechDotNetGS.Models;
using OceanTechDotNetGS.Repository;

namespace OceanTechDotNetGS.Controllers
{
    public class RegistroVazamentoController : Controller
    {
        private readonly IRegistroVazamentosRepository _registroVazamentoRepository;

        public RegistroVazamentoController(IRegistroVazamentosRepository registroVazamentoRepository)
        {
            _registroVazamentoRepository = registroVazamentoRepository;
        }

        // GET: RegistroVazamentos
        public async Task<IActionResult> Index()
        {
            var registroVazamentos = await _registroVazamentoRepository.ListarTodosAsync();
            return View(registroVazamentos);
        }

        // GET: RegistroVazamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVazamento = await _registroVazamentoRepository.ObterPorIdAsync(id.Value);
            if (registroVazamento == null)
            {
                return NotFound();
            }

            return View(registroVazamento);
        }

        // GET: RegistroVazamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroVazamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDetecao,TipoSeveridade,DescricaoVazamento,RegistroUsuarioId")] RegistroVazamento registroVazamento)
        {
            if (ModelState.IsValid)
            {
                await _registroVazamentoRepository.AdicionarAsync(registroVazamento);
                return RedirectToAction(nameof(Index));
            }
            return View(registroVazamento);
        }

        // GET: RegistroVazamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVazamento = await _registroVazamentoRepository.ObterPorIdAsync(id.Value);
            if (registroVazamento == null)
            {
                return NotFound();
            }

            return View(registroVazamento);
        }

        // POST: RegistroVazamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDetecao,TipoSeveridade,DescricaoVazamento,RegistroUsuarioId")] RegistroVazamento registroVazamento)
        {
            if (id != registroVazamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _registroVazamentoRepository.AtualizarAsync(registroVazamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_registroVazamentoRepository.RegistroVazamentoExists(registroVazamento.Id))
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
            return View(registroVazamento);
        }

        // GET: RegistroVazamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVazamento = await _registroVazamentoRepository.ObterPorIdAsync(id.Value);
            if (registroVazamento == null)
            {
                return NotFound();
            }

            return View(registroVazamento);
        }

        // POST: RegistroVazamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroVazamento = await _registroVazamentoRepository.ObterPorIdAsync(id);
            if (registroVazamento != null)
            {
                await _registroVazamentoRepository.RemoverAsync(registroVazamento);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
