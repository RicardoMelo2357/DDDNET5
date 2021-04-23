using Dominio.Argumentos.Usuario.UsuarioEndereco;
using Dominio.Interfaces.Servicos.Base;

namespace Dominio.Interfaces.Servicos.Usuario
{
    public interface IServicoUsuarioEndereco : IServicoBase
    {
        UsuarioEnderecoResponse AdicionarEnderecoUsuario(UsuarioEnderecoRequest request);
    }
}
