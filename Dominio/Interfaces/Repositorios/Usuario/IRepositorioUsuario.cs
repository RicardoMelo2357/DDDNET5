using Dominio.Interfaces.Repositorios.Base;
using _Usuario = Dominio.Entidades.Usuario.Usuario;

namespace Dominio.Interfaces.Repositorios.Usuario
{
    public interface IRepositorioUsuario : IRepositorioBase <_Usuario, int> { }
}
