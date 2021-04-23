using Dominio.Argumentos.Endereco;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos.Endereco
{
    public interface IServicoEndereco : IServicoBase
    {
        EnderecoResponse Adicionar(EnderecoRequest request);
        IEnumerable<EnderecoResponse> AdicionarLista(IEnumerable<EnderecoRequest> request);
        IEnumerable<EnderecoResponse> ValidarLista(IEnumerable<EnderecoRequest> request);
        EnderecoResponse Alterar(EnderecoRequest request);
        EnderecoResponse Selecionar(int id);
        IEnumerable<EnderecoResponse> Listar();
        IEnumerable<EnderecoResponse> ListarAtivos();
    }
}
