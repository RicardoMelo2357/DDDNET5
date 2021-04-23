using Dominio.Argumentos.Usuario.UsuarioEndereco;
using Dominio.Interfaces.Servicos.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Util.ControllerBase;

namespace API.Usuario.Controllers.UsuarioEndereco
{
    [Route("api/usuarioEndereco")]
    [ApiController]
    public class UsuarioEnderecoController : BaseController<UsuarioEnderecoRequest, UsuarioEnderecoResponse>
    {
        private readonly IServicoUsuarioEndereco _servico;
        public UsuarioEnderecoController(IServicoUsuarioEndereco servico)
        {
            _servico = servico;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioEnderecoResponse), (int)HttpStatusCode.OK)]
        public IActionResult AdicionarEnderecoUsuario(UsuarioEnderecoRequest request)
        {
            try
            {
                var result = _servico.AdicionarEnderecoUsuario(request);
                return Response(result, _servico);
            }
            catch (Exception e)
            {
                return ResponseException(e);
            }
        }
    }
}
