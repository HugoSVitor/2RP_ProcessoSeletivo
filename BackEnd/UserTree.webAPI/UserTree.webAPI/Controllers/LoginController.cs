using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserTree.webAPI.Interfaces;
using UserTree.webAPI.Repositories;
using UserTree.webAPI.ViewModels;

namespace UserTree.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var UsuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);
            try
            {
                if (UsuarioBuscado != null)
                {
                    var Claims = new[]
                    {
                    new Claim( "email", UsuarioBuscado.Email),
                    new Claim( ClaimTypes.Role,UsuarioBuscado.IdTipoU.ToString()),
                    new Claim( JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim( "role", UsuarioBuscado.IdTipoU.ToString() )
                    };

                    var Chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usertree-chave-autentica"));
                    var Credenciais = new SigningCredentials(Chave, SecurityAlgorithms.HmacSha256);
                    var Token = new JwtSecurityToken
                        (
                            issuer: "UserTree.webAPI",
                            audience: "UserTree.webAPI",
                            claims: Claims,
                            signingCredentials: Credenciais
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(Token)
                    });
                }
                else
                {
                    return NotFound("Email ou senha inválidos! Usuário não encontrado!");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
