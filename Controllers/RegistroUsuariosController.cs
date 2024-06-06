using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OceanTechDotNetGS.Models;
using OceanTechDotNetGS.Repository;

namespace OceanTechDotNetGS.Controllers
{
    public class RegistroVazamentosController : Controller
    {
        private readonly IRegistroVazamentoRepository _registroVazamentoRepository;

        public RegistroVazamentosController(IRegistroVazamentoRepository registroVazamentoRepository)
        {
            _registroVazamentoRepository = registroVazamentoRepository ?? throw new ArgumentNullException(nameof(registroVazamentoRepository));
        }

        // GET: RegistroVazamentos
        public async Task<IActionResult> Index()
        {
            var registroVazamentos = await _registroVazamentoRepository.ListarTodosAsync();
            return View(registroVazamentos);
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
