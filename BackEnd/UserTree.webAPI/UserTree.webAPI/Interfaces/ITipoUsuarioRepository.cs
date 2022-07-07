using System.Collections.Generic;
using UserTree.webAPI.Domains;

namespace UserTree.webAPI.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario novoTipoU);

        void Deletar(int idTipoU);

        List<TipoUsuario> ListarTodos();
    }
}
