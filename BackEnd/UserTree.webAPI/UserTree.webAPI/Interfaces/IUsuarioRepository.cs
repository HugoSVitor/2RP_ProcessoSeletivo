using System.Collections.Generic;
using UserTree.webAPI.Domains;

namespace UserTree.webAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        void Deletar(int idUsuario);
        Usuario BuscarUsuario(int idUsuario);
        List<Usuario> ListarTodos();
        void AlterarInfoUsuario(int idUsuario, Usuario novasInfo);
        public Usuario Login(string email, string Senha);
        void AtualizarGeral(int id, Usuario novasInfo);
        void AtualizarAdmRoot(int id, Usuario novasInfo);
    }
}
