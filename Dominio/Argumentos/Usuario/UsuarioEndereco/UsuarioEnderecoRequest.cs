using Dominio.Argumentos.Endereco;
using System.Collections.Generic;

namespace Dominio.Argumentos.Usuario.UsuarioEndereco
{
    public class UsuarioEnderecoRequest
    {
        public UsuarioRequest Usuario { get; set; }
        public IEnumerable<EnderecoRequest> Endereco { get; set; }
    }
}
