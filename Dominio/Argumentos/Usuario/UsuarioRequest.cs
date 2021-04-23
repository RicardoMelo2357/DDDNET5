using Dominio.Entidades.Base;
using System;

namespace Dominio.Argumentos.Usuario
{
    public class UsuarioRequest : EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
