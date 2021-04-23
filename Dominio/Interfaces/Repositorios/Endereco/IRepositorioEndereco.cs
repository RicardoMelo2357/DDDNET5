using Dominio.Interfaces.Repositorios.Base;
using _Endereco = Dominio.Entidades.Endereco.Endereco;

namespace Dominio.Interfaces.Repositorios.Endereco
{
    public interface IRepositorioEndereco : IRepositorioBase<_Endereco, int> { }
}
