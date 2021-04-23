using Dominio.Argumentos.Endereco;
using Dominio.Interfaces.Servicos.Endereco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Util.ControllerBase;

namespace API.Endereco.Controllers.Endereco
{
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : BaseController<EnderecoRequest, EnderecoResponse>
    {
        private readonly IServicoEndereco _servico;
        public EnderecoController(IServicoEndereco servico)
        {
            _servico = servico;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public IActionResult Adicionar(EnderecoRequest request)
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

        [HttpPost("adicionarLista")]
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public IActionResult AdicionarLista(IEnumerable<EnderecoRequest> request)
        {
            try
            {
                var result = _servico.AdicionarLista(request);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
        public IActionResult Alterar(EnderecoRequest request)
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
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType(typeof(EnderecoResponse), (int)HttpStatusCode.OK)]
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
