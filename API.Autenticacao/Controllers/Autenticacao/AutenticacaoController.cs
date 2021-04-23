using Dominio.Argumentos.Autenticacao;
using Dominio.Interfaces.Servicos.Autenticacao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Util.ControllerBase;

namespace API.Autenticacao.Controllers.Autenticacao
{
    [Route("api/autenticacao")]
    [ApiController]
    public class AutenticacaoController : BaseController<AutenticacaoRequest, AutenticacaoResponse>
    {
        private readonly IServicoAutenticacao _servico;
        public AutenticacaoController(IServicoAutenticacao servico)
        {
            _servico = servico;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AutenticacaoResponse), (int)HttpStatusCode.OK)]
        public IActionResult Autenticar(AutenticacaoRequest request)
        {
            try
            {
                var result = _servico.Autenticar(request);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }
    }
}
