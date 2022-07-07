using System.Collections.Generic;
using System.Linq;
using UserTree.webAPI.Context;
using UserTree.webAPI.Domains;
using UserTree.webAPI.Interfaces;

namespace UserTree.webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private UserTreeContext ctx = new UserTreeContext();

        public void Cadastrar(TipoUsuario novoTipoU)
        {
            ctx.TipoUsuarios.Add(novoTipoU);
            ctx.SaveChangesAsync();
        }

        public void Deletar(int idTipoU)
        {
            var encontrar = ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoU == idTipoU);
            ctx.TipoUsuarios.Remove(encontrar);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
