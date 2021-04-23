using AutoMapper;
using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Repositorios.Usuario;
using Dominio.Interfaces.Servicos.Endereco;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using _Usuario = Dominio.Entidades.Usuario.Usuario;

namespace Dominio.Servicos.Usuario
{
    public class ServicoUsuario : Notifiable, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;
        private readonly IServicoEndereco _servicoEndereco;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IMapper mapper, IServicoEndereco servicoEndereco)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
            _servicoEndereco = servicoEndereco;
        }

        public UsuarioResponse Adicionar(UsuarioRequest request)
        {
            if (request == null) { AddNotification("Adicionar Usuario", Mensagens.DADOS_NAO_INFORMADOS); return null; }

            var entidade = new _Usuario(request);
            AddNotifications(entidade);
            if (IsInvalid()) return null;

            return _mapper.Map<UsuarioResponse>(_repositorioUsuario.Adicionar(entidade));
        }

        public UsuarioResponse Alterar(UsuarioRequest request)
        {
            if (request == null) { AddNotification("Alterar Usuario", Mensagens.DADOS_NAO_INFORMADOS); return null; }
            if (request.Id <= 0) { AddNotification("Alterar Usuario", Mensagens.CAMPO_X0_INVALIDO.ToFormat("id")); return null; }

            var entidade = new _Usuario(request);
            AddNotifications(entidade);
            if (IsInvalid()) return null;

            var usuario = _repositorioUsuario.ObterPorId(request.Id);

            entidade.Atualizar(request);

            if(usuario == null)
                if (request == null) { AddNotification("Alterar Usuario", Mensagens.DADOS_NAO_ECONTRADOS); return null; }

            return _mapper.Map<UsuarioResponse>(_repositorioUsuario.Editar(entidade));
        }

        public IEnumerable<UsuarioResponse> Listar() => _mapper.Map<IEnumerable<UsuarioResponse>>(_repositorioUsuario.Listar().ToList());
        public IEnumerable<UsuarioResponse> ListarAtivos() => _mapper.Map<IEnumerable<UsuarioResponse>>(_repositorioUsuario.ListarPor(x => x.Ativo.Value).ToList());
        public UsuarioResponse Selecionar(int id) => _mapper.Map<UsuarioResponse>(_repositorioUsuario.ObterPorId(id));
    }
}
