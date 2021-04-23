using Dominio.Argumentos.Autenticacao;
using Dominio.Interfaces.Servicos.Base;

namespace Dominio.Interfaces.Servicos.Autenticacao
{
    public interface IServicoAutenticacao : IServicoBase
    {
        AutenticacaoResponse Autenticar(AutenticacaoRequest request);
    }
}
