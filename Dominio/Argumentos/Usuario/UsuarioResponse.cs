using Dominio.Argumentos.Endereco;
using System;
using System.Collections.Generic;

namespace Dominio.Argumentos.Usuario
{
    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
