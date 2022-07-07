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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoURepository;
        public TipoUsuarioController()
        {
            _tipoURepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoURepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoU)
        {
            try
            {
                _tipoURepository.Cadastrar(novoTipoU);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("TipoUsuarios/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _tipoURepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
