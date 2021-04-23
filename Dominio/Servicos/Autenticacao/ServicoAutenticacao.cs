using Dominio.Argumentos.Autenticacao;
using Dominio.Interfaces.Repositorios.Usuario;
using Dominio.Interfaces.Servicos.Autenticacao;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;

namespace Dominio.Servicos.Autenticacao
{
    public class ServicoAutenticacao : Notifiable, IServicoAutenticacao
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IServicoToken _servicoToken;

        public ServicoAutenticacao(IRepositorioUsuario repositorioUsuario, IServicoToken servicoToken)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicoToken = servicoToken;
        }

        public AutenticacaoResponse Autenticar(AutenticacaoRequest request)
        {
            if(request == null)
            {
                AddNotification("Autenticacao", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            var entidade = _repositorioUsuario.ObterPor(x => x.Email.ToUpper() == request.Email.ToUpper());

            if(entidade == null)
            {
                AddNotification("Autenticacao", Mensagens.CREDENCIAIS_INCORRETAS);
                return null;
            }

            if(entidade.Senha != request.Senha)
            {
                AddNotification("Autenticacao", Mensagens.CREDENCIAIS_INCORRETAS);
                return null;
            }

            var token = _servicoToken.GerarToken(entidade.Id);
            return new AutenticacaoResponse { Token = token };
        }
    }
}
