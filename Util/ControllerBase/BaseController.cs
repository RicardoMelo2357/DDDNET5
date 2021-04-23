using Dominio.Interfaces.Servicos.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using _ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace Util.ControllerBase
{
    [ApiController]
    public class BaseController<TRequest, TResponse> : _ControllerBase where TRequest : class where TResponse : class
    {
        private IServicoBase _servicoBase;

        public BaseController() { }

        public new IActionResult Response<T>(T result, IServicoBase servicoBase)
        {
            _servicoBase = servicoBase;

            if (_servicoBase.Notifications.Any())
                return StatusCode(servicoBase.Notifications.FirstOrDefault()?.Property == "usuarioLogado" ? 403 : 400, new { errors = servicoBase.Notifications });

            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected new IActionResult Response(IServicoBase servicoBase)
        {
            _servicoBase = servicoBase;

            if (servicoBase.Notifications.Any())
                return StatusCode(servicoBase.Notifications.FirstOrDefault()?.Property == "usuarioLogado" ? 403 : 400, new { errors = servicoBase.Notifications });

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected IActionResult ResponseException(Exception ex) => 
            StatusCode(500, new { errors = new List<object> { new { Message = "Ops! Um erro inesperado aconteceu, por favor entre em contato com o administrador do sistema!", exception = ex.ToString() } } });
    }
}
