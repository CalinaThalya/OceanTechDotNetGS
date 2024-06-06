using System.Collections.Generic;
using System.Threading.Tasks;
using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public interface IRegistroVazamentosRepository
    {
        Task<List<RegistroVazamento>> ListarTodosAsync();
        Task<RegistroVazamento> ObterPorIdAsync(int id);
        Task AdicionarAsync(RegistroVazamento registroVazamento);
        Task AtualizarAsync(RegistroVazamento registroVazamento);
        Task RemoverAsync(RegistroVazamento registroVazamento);
        bool RegistroVazamentoExists(int id); // Adicionar este método
    }
}
