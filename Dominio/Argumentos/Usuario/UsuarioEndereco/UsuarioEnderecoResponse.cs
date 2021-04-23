using Dominio.Argumentos.Endereco;
using System.Collections.Generic;

namespace Dominio.Argumentos.Usuario.UsuarioEndereco
{
    public class UsuarioEnderecoResponse
    {
        public UsuarioResponse Usuario { get; set; }
        public IEnumerable<EnderecoResponse> Endereco { get; set; }
    }
}
