using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UserTree.webAPI.Domains;
using UserTree.webAPI.Interfaces;
using UserTree.webAPI.Repositories;

namespace UserTree.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("/Deletar/{idUsuario}")]
        public IActionResult DeletarUsuario(int idUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(idUsuario);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("/Buscar/{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarUsuario(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPut("/Atualizar/{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario novoUsuario)
        {
            if (novoUsuario != null)
            {
                try
                {
                    _usuarioRepository.AlterarInfoUsuario(idUsuario, novoUsuario);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                    throw;
                }
            }
            return BadRequest();
        }

        [HttpPatch("AtualizarGeral/{id}")]
        public IActionResult AtualizarGeral(int id, Usuario novasInfo)
        {
            try
            {
                _usuarioRepository.AtualizarGeral(id, novasInfo);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPatch("AtualizarAdmRoot/{id}")]
        public IActionResult AtualizarAdmRoot(int id, Usuario novasInfo)
        {
            try
            {
                _usuarioRepository.AtualizarAdmRoot(id, novasInfo);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
