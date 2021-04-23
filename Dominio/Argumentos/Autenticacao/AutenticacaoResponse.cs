using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Autenticacao
{
    public class AutenticacaoResponse : ArgumentoBase
    {
        public string Token { get; set; }
    }
}
