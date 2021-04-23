using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos.Usuario
{
    public interface IServicoUsuario : IServicoBase
    {
        UsuarioResponse Adicionar(UsuarioRequest request);
        UsuarioResponse Alterar(UsuarioRequest request);
        UsuarioResponse Selecionar(int id);
        IEnumerable<UsuarioResponse> Listar();
        IEnumerable<UsuarioResponse> ListarAtivos();
    }
}
