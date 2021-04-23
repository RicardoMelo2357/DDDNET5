using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Base;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Dominio.Entidades.Usuario
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        
        public Usuario() { }
        public Usuario(UsuarioRequest request)
        {
            Nome = request.Nome;
            SobreNome = request.SobreNome;
            DataNascimento = request.DataNascimento;
            CPF = request.CPF;
            Email = request.Email;
            Senha = request.Senha;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Nome"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.SobreNome, Mensagens.CAMPO_X0_INVALIDO.ToFormat("SobreNome"));
            new AddNotifications<Usuario>(this).IfLowerOrEqualsThan(x => x.DataNascimento, DateTime.MinValue, Mensagens.CAMPO_X0_INVALIDO.ToFormat("DataNascimento"));
            new AddNotifications<Usuario>(this).IfAreEquals(x => x.DataNascimento, DateTime.MaxValue, Mensagens.CAMPO_X0_INVALIDO.ToFormat("DataNascimento"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.CPF, Mensagens.CAMPO_X0_INVALIDO.ToFormat("CPF"));
            new AddNotifications<Usuario>(this).IfNotEmail(x => x.Email, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Email"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Senha"));
        }

        public void Atualizar(UsuarioRequest request)
        {
            Nome = request.Nome;
            SobreNome = request.SobreNome;
            DataNascimento = request.DataNascimento;
            CPF = request.CPF;
            Email = request.Email;
            Senha = request.Senha;
            if (request.Ativo.HasValue) Ativo = request.Ativo.Value;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Nome"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.SobreNome, Mensagens.CAMPO_X0_INVALIDO.ToFormat("SobreNome"));
            new AddNotifications<Usuario>(this).IfLowerOrEqualsThan(x => x.DataNascimento, DateTime.MinValue, Mensagens.CAMPO_X0_INVALIDO.ToFormat("DataNascimento"));
            new AddNotifications<Usuario>(this).IfAreEquals(x => x.DataNascimento, DateTime.MaxValue, Mensagens.CAMPO_X0_INVALIDO.ToFormat("DataNascimento"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.CPF, Mensagens.CAMPO_X0_INVALIDO.ToFormat("CPF"));
            new AddNotifications<Usuario>(this).IfNotEmail(x => x.Email, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Email"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.CAMPO_X0_INVALIDO.ToFormat("Senha"));
        }
    }
}
