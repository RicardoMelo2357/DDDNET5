using Dominio.Interfaces.Repositorios.Usuario;
using Infra.Persistencia.Repositorios.Base;
using _Usuario = Dominio.Entidades.Usuario.Usuario;

namespace Infra.Persistencia.Repositorios.Usuario
{
    public class RepositorioUsuario : RepositorioBase<_Usuario, int>, IRepositorioUsuario
    {
        protected readonly Contexto _context;
        public RepositorioUsuario(Contexto context) : base(context)
        {
            _context = context;
        }
    }
}
