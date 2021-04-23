using AutoMapper;
using Dominio.Argumentos.Endereco;
using Dominio.Argumentos.Usuario;
using Dominio.Argumentos.Usuario.UsuarioEndereco;
using Dominio.Entidades.Endereco;
using Dominio.Entidades.Usuario;

namespace Infra.Persistencia.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioEnderecoRequest, Usuario>();
            CreateMap<Usuario, UsuarioEnderecoRequest>();
            CreateMap<UsuarioRequest, Usuario>();

            CreateMap<Endereco, EnderecoResponse>();
            CreateMap<EnderecoRequest, Endereco>();
            CreateMap<UsuarioEnderecoRequest, Endereco>();
            CreateMap<Endereco, UsuarioEnderecoRequest>();
        }
    }
}
