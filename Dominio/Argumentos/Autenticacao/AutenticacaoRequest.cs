using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Autenticacao
{
    public class AutenticacaoRequest : ArgumentoBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
