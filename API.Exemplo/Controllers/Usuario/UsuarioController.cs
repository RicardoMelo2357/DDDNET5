using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Util.ControllerBase;

namespace API.Usuario.Controllers.Usuario
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : BaseController<UsuarioRequest, UsuarioResponse>
    {
        private readonly IServicoUsuario _servico;
        public UsuarioController(IServicoUsuario servico)
        {
            _servico = servico;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public IActionResult Adicionar(UsuarioRequest request)
        {
            try
            {
                var result = _servico.Adicionar(request);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
        public IActionResult Alterar(UsuarioRequest request)
        {
            try
            {
                var result = _servico.Alterar(request);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }

        [HttpGet("listarAtivos")]
        [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
        public IActionResult ListarAtivos()
        {
            try
            {
                var result = _servico.ListarAtivos();
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
        public IActionResult Listar()
        {
            try
            {
                var result = _servico.Listar();
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
        public IActionResult Selecionar(int id)
        {
            try
            {
                var result = _servico.Selecionar(id);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }
    }
}
