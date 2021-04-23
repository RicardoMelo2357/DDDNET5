using AutoMapper;
using Dominio.Argumentos.Endereco;
using Dominio.Argumentos.Usuario;
using Dominio.Argumentos.Usuario.UsuarioEndereco;
using Dominio.Interfaces.Repositorios.Endereco;
using Dominio.Interfaces.Repositorios.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using _Endereco = Dominio.Entidades.Endereco.Endereco;
using _Usuario = Dominio.Entidades.Usuario.Usuario;

namespace Dominio.Servicos.Usuario
{
    public class ServicoUsuarioEndereco : Notifiable, IServicoUsuarioEndereco
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioEndereco _repositorioEndereco;

        public ServicoUsuarioEndereco(IMapper mapper, IRepositorioUsuario repositorioUsuario, IRepositorioEndereco repositorioEndereco)
        {
            _mapper = mapper;
            _repositorioUsuario = repositorioUsuario;
            _repositorioEndereco = repositorioEndereco;
        }
        public UsuarioEnderecoResponse AdicionarEnderecoUsuario(UsuarioEnderecoRequest request)
        {
            if (request == null) { AddNotification("Adicionar Usuario", Mensagens.DADOS_NAO_INFORMADOS); return null; }

            var entidadeEndereco = new _Endereco(request.Endereco);
            var entidadeUsuario = new _Usuario(request.Usuario);

            AddNotifications(entidadeUsuario);
            AddNotifications(entidadeEndereco);
            if (IsInvalid()) return null;

            if (_repositorioUsuario.Existe(x => x.CPF == request.Usuario.CPF))
            {
                AddNotification("Adicionar Usuario", Mensagens.O_X0_INFORMADO_JA_ESTA_CADASTRADO_NO_SISTEMA.ToFormat("Usuario"));
                return null;
            }

            foreach (var end in request.Endereco)
                if (_repositorioEndereco.Existe(x => x.Logradouro.ToUpper() == end.Logradouro.ToUpper() && x.Municipio.ToUpper() == end.Municipio.ToUpper() && x.Numero == end.Numero))
                {
                    AddNotification("Adicionar Usuario", Mensagens.O_X0_INFORMADO_JA_ESTA_CADASTRADO_NO_SISTEMA.ToFormat("Endereco"));
                    return null;
                }

            var usr = _mapper.Map<_Usuario>(request.Usuario);
            var usuario = _repositorioUsuario.Adicionar(usr);

            foreach (var end in request.Endereco)
                end.UsuarioId = usuario.Id;

            var lstEnd = _mapper.Map<IEnumerable<_Endereco>>(request.Endereco);
            var endereco = _repositorioEndereco.AdicionarLista(lstEnd);

            return new UsuarioEnderecoResponse { Endereco = _mapper.Map<IEnumerable<EnderecoResponse>>(endereco), Usuario = _mapper.Map<UsuarioResponse>(usuario) };
        }
    }
}
