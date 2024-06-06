using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public interface IEmpresaRepository
    {
        Empresa ObterPorId(int id);
        List<Empresa> ListarTodas();
        void Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Remover(Empresa empresa);
        bool EmpresaExists(int id);
    }
}
