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
        private readonly IRegistroVazamentoRepository _registroVazamentoRepository;

        public RegistroVazamentoController(IRegistroVazamentoRepository registroVazamentoRepository)
        {
            _registroVazamentoRepository = registroVazamentoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var registroVazamentos = await _registroVazamentoRepository.ListarTodosAsync();
            return View(registroVazamentos);
        }

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

        public IActionResult Create()
        {
            return View();
        }

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
