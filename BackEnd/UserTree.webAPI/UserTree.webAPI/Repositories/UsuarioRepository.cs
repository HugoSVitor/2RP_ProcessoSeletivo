using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserTree.webAPI.Context;
using UserTree.webAPI.Domains;
using UserTree.webAPI.Interfaces;
using UserTree.webAPI.Utils;

namespace UserTree.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private UserTreeContext ctx = new UserTreeContext();

        public void AlterarInfoUsuario(int idUsuario, Usuario novasInfo)
        {
            var usuarioNovaInfo = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
            usuarioNovaInfo = novasInfo;
            ctx.Usuarios.Update(usuarioNovaInfo);
            ctx.SaveChanges();
        }

        public void AtualizarAdmRoot(int id, Usuario novasInfo)
        {
            Usuario atualizando = BuscarUsuario(id);
            atualizando.Nome = novasInfo.Nome;
            atualizando.StatusU = novasInfo.StatusU;
            atualizando.IdTipoU = novasInfo.IdTipoU;

            ctx.Update(atualizando);
            ctx.SaveChanges();
        }

        public void AtualizarGeral(int id, Usuario novasInfo)
        {
            Usuario atualizando = BuscarUsuario(id);
            atualizando.Nome = novasInfo.Nome;
            atualizando.StatusU = novasInfo.StatusU;

            ctx.Update(atualizando);
            ctx.SaveChanges();
        }

        public Usuario BuscarUsuario(int idUsuario)
        {
            return ctx.Usuarios.Include(c => c.IdTipoUNavigation).FirstOrDefault(id => id.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }


        public void Deletar(int idUsuario)
        {
            var encontrar = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
            ctx.Usuarios.Remove(encontrar);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUNavigation).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {

                if (senha.Length != 32)
                {
                    var SenhaBanco = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

                    if (SenhaBanco != null)
                    {
                        SenhaBanco.Senha = Criptografia.GerarHash(SenhaBanco.Senha);

                        ctx.SaveChanges();

                        return usuario;
                    }
                }
                bool confere = Criptografia.Comparar(senha, usuario.Senha);

                if (confere)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}
