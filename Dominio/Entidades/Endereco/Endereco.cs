using Dominio.Argumentos.Endereco;
using Dominio.Entidades.Base;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace Dominio.Entidades.Endereco
{
    public class Endereco : EntidadeBase
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Municipio { get; private set; }
        public string Cep { get; private set; }
        public string Estado { get; private set; }
        public int UsuarioId { get; private set; }
        public virtual Dominio.Entidades.Usuario.Usuario Usuario { get; private set; }

        public Endereco() { }
        public Endereco(EnderecoRequest request)
        {
            Logradouro = request.Logradouro;
            Numero = request.Numero;
            Municipio = request.Municipio;
            Cep = request.Cep;
            Estado = request.Estado;

            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Logradouro);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Numero);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Municipio);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Cep);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Estado);
        }

        public Endereco(IEnumerable<EnderecoRequest> request)
        {
            foreach (var item in request)
            {
                Logradouro = item.Logradouro;
                Numero = item.Numero;
                Municipio = item.Municipio;
                Cep = item.Cep;
                Estado = item.Estado;

                new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Logradouro);
                new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Numero);
                new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Municipio);
                new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Cep);
                new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Estado);
            }
        }

        public void Atualizar(EnderecoRequest request)
        {
            Logradouro = request.Logradouro;
            Numero = request.Numero;
            Municipio = request.Municipio;
            Cep = request.Cep;
            Estado = request.Estado;

            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Logradouro);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Numero);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Municipio);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Cep);
            new AddNotifications<Endereco>(this).IfNullOrEmpty(x => x.Estado);
        }
    }
}
