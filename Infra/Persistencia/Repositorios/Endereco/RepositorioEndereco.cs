using Dominio.Interfaces.Repositorios.Endereco;
using Infra.Persistencia.Repositorios.Base;
using _Endereco = Dominio.Entidades.Endereco.Endereco;

namespace Infra.Persistencia.Repositorios.Endereco
{
    public class RepositorioEndereco : RepositorioBase<_Endereco, int>, IRepositorioEndereco
    {
        protected readonly Contexto _context;
        public RepositorioEndereco(Contexto context) : base(context)
        {
            _context = context;
        }
    }
}
