using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public interface IUsuarioRepository
    {
        Usuario ObterPorId(int id);
        List<Usuario> ListarTodos();
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
    }
}