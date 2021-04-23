using AutoMapper;
using Dominio.Argumentos.Endereco;
using Dominio.Argumentos.Usuario.UsuarioEndereco;
using Dominio.Interfaces.Repositorios.Endereco;
using Dominio.Interfaces.Servicos.Endereco;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using System.Linq;
using _Endereco = Dominio.Entidades.Endereco.Endereco;

namespace Dominio.Servicos.Endereco
{
    public class ServicoEndereco : Notifiable, IServicoEndereco
    {
        private readonly IRepositorioEndereco _repositorioEndereco;
        private readonly IMapper _mapper;

        public ServicoEndereco(IRepositorioEndereco repositorioEndereco, IMapper mapper)
        {
            _repositorioEndereco = repositorioEndereco;
            _mapper = mapper;
        }
        public EnderecoResponse Adicionar(EnderecoRequest request)
        {
            if (request == null) { AddNotification("Adicionar Usuario", Mensagens.DADOS_NAO_INFORMADOS); return new EnderecoResponse(); }

            var entidade = new _Endereco(request);
            AddNotifications(entidade);
            if (IsInvalid()) return new EnderecoResponse();

            return _mapper.Map<EnderecoResponse>(_repositorioEndereco.Adicionar(entidade));
        }

        public EnderecoResponse Alterar(EnderecoRequest request)
        {
            if (request == null) { AddNotification("Alterar Endereco", Mensagens.DADOS_NAO_INFORMADOS); return new EnderecoResponse(); }

            var entidade = _repositorioEndereco.ObterPorId(request.Id);

            if(entidade == null) { AddNotification("Alterar Endereco", Mensagens.DADOS_NAO_INFORMADOS); return new EnderecoResponse(); }

            entidade.Atualizar(request);

            return _mapper.Map<EnderecoResponse>(_repositorioEndereco.Editar(entidade));
        }

        public IEnumerable<EnderecoResponse> AdicionarLista(IEnumerable<EnderecoRequest> request)
        {
            var listaEndereco = _mapper.Map<IEnumerable<Dominio.Entidades.Endereco.Endereco>>(ValidarLista(request));
            AddNotifications(listaEndereco);
            if(IsInvalid()) return Enumerable.Empty<EnderecoResponse>(); 
            return _mapper.Map<IEnumerable<EnderecoResponse>>(_repositorioEndereco.AdicionarLista(listaEndereco));
        }

        public IEnumerable<EnderecoResponse> ValidarLista(IEnumerable<EnderecoRequest> request)
        {
            if (!request.Any()) { AddNotification("Adicionar Endereco", Mensagens.DADOS_NAO_INFORMADOS); return Enumerable.Empty<EnderecoResponse>(); }

            foreach (var endereco in request)
            {
                var entidade = new Dominio.Entidades.Endereco.Endereco(endereco);
                AddNotifications(entidade);
                if (IsInvalid()) { AddNotification("Adicionar Endereco", Mensagens.DADOS_INVALIDOS); return Enumerable.Empty<EnderecoResponse>(); }
            }

            return _mapper.Map<IEnumerable<EnderecoResponse>>(request);
        }

        public EnderecoResponse Selecionar(int id) => _mapper.Map<EnderecoResponse>(_repositorioEndereco.ObterPorId(id));
        public IEnumerable<EnderecoResponse> Listar() => _mapper.Map<IEnumerable<EnderecoResponse>>(_repositorioEndereco.Listar());
        public IEnumerable<EnderecoResponse> ListarAtivos() => _mapper.Map<IEnumerable<EnderecoResponse>>(_repositorioEndereco.ListarPor(x => x.Ativo.Value));

        public UsuarioEnderecoResponse AdicionarEnderecoUsuario(UsuarioEnderecoRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
