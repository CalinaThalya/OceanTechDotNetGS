using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public class RegistroVazamentoRepository : IRegistroVazamentoRepository
    {
        private readonly Contexto _contexto;

        public RegistroVazamentoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<RegistroVazamento>> ListarTodosAsync()
        {
            return await _contexto.RegistroVazamentos.ToListAsync();
        }

        public async Task<RegistroVazamento> ObterPorIdAsync(int id)
        {
            return await _contexto.RegistroVazamentos.FindAsync(id);
        }

        public async Task AdicionarAsync(RegistroVazamento registroVazamento)
        {
            _contexto.RegistroVazamentos.Add(registroVazamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(RegistroVazamento registroVazamento)
        {
            _contexto.Entry(registroVazamento).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task RemoverAsync(RegistroVazamento registroVazamento)
        {
            _contexto.RegistroVazamentos.Remove(registroVazamento);
            await _contexto.SaveChangesAsync();
        }

        public bool RegistroVazamentoExists(int id)
        {
            return _contexto.RegistroVazamentos.Any(e => e.Id == id);
        }
    }
}
