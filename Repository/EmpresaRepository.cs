using System.Linq;
using System.Collections.Generic;
using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Contexto _context;

        public EmpresaRepository(Contexto context)
        {
            _context = context;
        }

        public Empresa? ObterPorId(int id)
{
    return _context.Empresa.FirstOrDefault(e => e.Id == id) ?? null;
}

        public List<Empresa> ListarTodas()
        {
            return _context.Empresa.ToList();
        }

       public void Adicionar(Empresa empresa)
{
    _context.Empresa.Add(empresa);
    _context.SaveChanges();
}

        public void Atualizar(Empresa empresa)
        {
            _context.Empresa.Update(empresa);
            _context.SaveChanges();
        }

        public void Remover(Empresa empresa)
        {
            _context.Empresa.Remove(empresa);
            _context.SaveChanges();
        }

        public bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}
