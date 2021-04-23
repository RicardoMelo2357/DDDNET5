using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Endereco
{
    public class EnderecoResponse : ArgumentoBase
    {
        public int UsuarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
    }
}
