using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using OceanTechDotNetGS.Models;

namespace OceanTechDotNetGS.Repository
{
    public class RegistroUsuarioRepository : IRegistroUsuarioRepository
    {
        private readonly Contexto _context;

        public RegistroUsuarioRepository(Contexto context)
        {
            _context = context;
        }

        public RegistroUsuario ObterPorId(int id)
        {
            return _context.RegistroUsuarios.FirstOrDefault(r => r.Id == id);
        }

        public List<RegistroUsuario> ListarTodos()
        {
            return _context.RegistroUsuarios.ToList();
        }

        public void Adicionar(RegistroUsuario registroUsuario)
        {
            _context.RegistroUsuarios.Add(registroUsuario);
            _context.SaveChanges();
        }

        public void Atualizar(RegistroUsuario registroUsuario)
        {
            _context.RegistroUsuarios.Update(registroUsuario);
            _context.SaveChanges();
        }

        public void Remover(RegistroUsuario registroUsuario)
        {
            _context.RegistroUsuarios.Remove(registroUsuario);
            _context.SaveChanges();
        }

       
        public List<Usuario> ListarTodosUsuarios()
        {
            return _context.Usuario.ToList();
        }
    }

    public interface IRegistroUsuarioRepository
    {
    }
}
