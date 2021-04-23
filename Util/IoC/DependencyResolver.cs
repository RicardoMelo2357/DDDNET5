using Dominio.Interfaces.Repositorios.Endereco;
using Dominio.Interfaces.Repositorios.Usuario;
using Dominio.Interfaces.Servicos.Autenticacao;
using Dominio.Interfaces.Servicos.Endereco;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Servicos.Autenticacao;
using Dominio.Servicos.Endereco;
using Dominio.Servicos.Usuario;
using Infra.Persistencia.AutoMapper;
using Infra.Persistencia.Repositorios.Endereco;
using Infra.Persistencia.Repositorios.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace Util.IoC
{
    public class DependencyResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            ResolveConfig(services);
            ResolveServicos(services);
            ResolveRepositorios(services);
        }

        private static void ResolveConfig(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton(new AutoMapperConfig().Config().CreateMapper());
        }

        private static void ResolveServicos(IServiceCollection services)
        {
            services.AddTransient<IServicoUsuario, ServicoUsuario>();
            services.AddTransient<IServicoEndereco, ServicoEndereco>();
            services.AddTransient<IServicoUsuarioEndereco, ServicoUsuarioEndereco>();
            services.AddTransient<IServicoAutenticacao, ServicoAutenticacao>();
            services.AddTransient<IServicoToken, ServicoToken>();
        }

        private static void ResolveRepositorios(IServiceCollection services)
        {
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioEndereco, RepositorioEndereco>();
        }
    }
}
