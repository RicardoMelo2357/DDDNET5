using Dominio.Interfaces.Servicos.Base;
using System.Security.Claims;

namespace Dominio.Interfaces.Servicos.Autenticacao
{
    public interface IServicoToken : IServicoBase
    {
        string GerarToken(int UsuarioId);
        string ObterValor(ClaimsPrincipal principal, string name);
        int ObterValorInt(ClaimsPrincipal principal, string name);
        string ObterSecret();
    }
}
