using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanTechDotNetGS.Models;
using OceanTechDotNetGS.Repository;
using System.Threading.Tasks;

namespace OceanTechDotNetGS.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        // GET: Empresas
        public IActionResult Index()
        {
            var empresas = _empresaRepository.ListarTodas();
            return View(empresas);
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _empresaRepository.ObterPorId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Empresa empresa)
{
    if (ModelState.IsValid)
    {
        try
        {
            _empresaRepository.Adicionar(empresa);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Ocorreu um erro ao criar a empresa: {ex.Message}");
        }
    }
    return View(empresa);
}
        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _empresaRepository.ObterPorId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _empresaRepository.Atualizar(empresa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_empresaRepository.EmpresaExists(id))
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
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _empresaRepository.ObterPorId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _empresaRepository.Remover(_empresaRepository.ObterPorId(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
